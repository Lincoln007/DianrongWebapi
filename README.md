# 点融webapi
1. 项目基于 asp.net core 2.0，挂到iis或者apache或者nginx都ok。
2. swagger 已集成，地址localhost:5000/swagger
3. 改配置后直接能用，作为一个服务给第三方系统调用,带token验证。
4. 算签名发请求的核心代码都在Site.Common下的DianrongHelper.cs文件中，还是用BouncyCastle，神器，再次安利一下。
5. 点融会给3个pem格式的证书文件, 这里用到两个，公钥私钥证书文件配置
```
private static string publicKeyFile = Path.Combine(AppContext.BaseDirectory, "rsa", "rsa_public_key.pem");
private static string privateKeyFile =Path.Combine(AppContext.BaseDirectory, "rsa", "rsa_private_key.pem");
```
6. 项目会有一些默认的传值，比如
企业基本信息推送的申请授信用途.
```csharp
/// <summary>
/// 申请授信用途
/// </summary>
/// <returns></returns>
[JsonProperty("apply_rc_purpose")]
public string RcPurpose
{
    get
    {
        return "原材料采购";
    }
}
```
理论上是根据点融提供的枚举来赋值，但是因为我们自身项目业务的，这里就给了默认的。
### 基本的验证套路
```csharp
public void OnActionExecuting(ActionExecutingContext context)
{
    var isContain = context.HttpContext.Request.Headers.TryGetValue(TOKEN_KEY,out StringValues token);

    if (!isContain || token!= Token)
    {
        context.Result = new ContentResult(){
            StatusCode = 401,
            Content =JsonConvert.SerializeObject(new DianrongBaseRspModel<dynamic>(){
                Result="error",
                ContentObj= new {
                    Code="999401",
                    Message="点融：非法请求"
                }
            }),
            ContentType = "application/json"
        };
    }
}
```
当token没有传的时候返回
```csharp
{
    "ContentObj": {
        "Code": "999401",
        "Message": "点融：非法请求"
    },
    "Body": null,
    "result": "error",
    "content": null
}
```

#### 完整的配置
+ 改成自己的channelId
+ url应该也不一样，需要特定的地址
```
{
  "DianrongConfig":{
    "ChannelId":"XX",
    "CompanyCreditUrl":"https://api-demo.dianrong.com/scpgateway/api/xxx/companyCredit",
    "ScpChainUrl":"https://api-demo.dianrong.com/scpgateway/api/xxx/loanReq/scpChain",
    "QueryLoanInfoUrl":"https://api-demo.dianrong.com/scpgateway/api/loan/queryLoanInfo",
    "SignUrl":"https://api-demo.dianrong.com/scpgateway/api/loan/signUrl",
    "QueryPaymentInfoUrl":"https://api-demo.dianrong.com/scpgateway/api/loan/queryPaymentInfo",
    "QueryRepaymentPlanUrl":"https://api-demo.dianrong.com/scpgateway/api/loan/queryRepaymentPlan",
    "GetRepaymentUrl":"https://api-demo.dianrong.com/scpgateway/api/auth/redirect",
    "CheckBlackListUrl":"https://api-demo.dianrong.com/scpgateway/api/xxx/checkBlacklist",
    "DianrongToken":"dianrongauth"
  }
}

```
json配置文件里面：
```
"DianrongToken":"dianrongauth"
```
这样接口请求的时候就要在header上带DianrongToken
![image](https://github.com/lousaibiao/DianrongWebapi/raw/master/%E7%82%B9%E8%9E%8Dtoken.png)


### 包含接口
都是根据返回的result是否是success来判断接口请求成功 or 失败
全都是随便写的数据

+ companyCredit 企业基本信息推送
+ ScpChainReq 贷款个人
+ ScpChainReq 贷款企业
+ QueryLoanInfo 查询贷款信息
+ Querypaymentinfo 查询还款信息
+ GetRepaymentUrl 还款界面
+ CheckBlackList 黑名单
+ 

#### 企业基本信息推送
+ 输入
```
{
  "rc_info": {
    "rc_level": "A1",
    "suggest_amount": "200000",
    "loan_period": "30"
  },
  "enterprise_info": {
    "enterprise_name": "楼工厂",
    "enterprise_no": "111111111111",
    "business_address": "地址1",
    "legal_person": "楼楼楼",
    "legal_person_id_card": "330782199101020431",
    "legal_person_phone": "15505991827",
    "contact_person": "楼楼楼",
    "contact_person_id_card": "330782197101087431",
    "contact_person_phone": "15505991827",
    "associated_person": "楼楼楼",
    "associated_person_id_card": "330782197101087431",
    "associated_person_phone": "15505991827",
    "affiliated_partner": "合作商1",
    "machine_nums": "20",
    "total_annual_debt": "2000000",
    "total_annual_revenue": "200000",
    "enterprise_industry": "执照业"
  },
  "history_info": {
    "trade_total": "1000000",
    "trade_frequency": "10",
    "avg_ttl_halfyear": "100000",
    "avg_ttl_quarter": "100000",
    "avg_frq_halfyear": "10",
    "avg_frq_quarter": "10",
    "avg_cpow_halfyear": "10000",
    "avg_cpow_quarter": "10000",
    "payment_days": "30"
  },
  "bank_info": {
    "bank_account_name": "楼楼楼",
    "bank_name": "工商银行",
    "bank_account_number": "6222020933001483077"
  },
  "other_info": {
    "pedestrians_credit_halfyear": "0",
    "other_platforms_nums": "0",
    "other_platforms_amount": "0"
  },
  "register_type": 1
}

```
+ 返回
```
{
    "contentObj": {
        "code": 20000,
        "codeDesc": "success",
        "message": "成功"
    },
    "body": "{\"code\":20000,\"message\":\"成功\"}",
    "result": "success",
    "content": "Pog70oZdgAlhCz+z4/7Ea2aMgR89zpESMQ1tGR+uI3zgHMQgYn31r+LLKCKWtydfkgv7NQ4xsoKfdi3zJDd53pvyxu6Duq+Sd0ub1bxMDYnzrerDbPIXqOS/AttzZCT1ubDL6mP3bzlEI0GSwAA1ggLR4QNlWTeEbPa9WmwBye38/b0JrXmC0BMjVsV99x7K7xEeGHxYFXYlJU824frdtoTaHE8W/XATtZIhbxoPLc0eXxtbe+KG2KMrQnm8z/WMqTdi2zRoGxjVJXXq7lrXg7AXt+CrqA5kqr1+MY2SZ9cvWyzXjhKLw/lgN1a6b89o+/11YQ5FBkeZg5aS9slI6Q=="
}
```

#### 贷款个人
+ 输入
```
{
    "sCP_CHAIN_loanApp": {
        "loan_appAmount": "1000.00",
        "loan_purpose": "原材料采购",
        "loan_maturityType": "按天",
        "loan_maturity": null,
        "loan_maturityDaily": "15",
        "loan_paymentMethod": "到期一次性还本付息",
        "loan_title": "陈工厂_TFB000123180067",
        "loan_description": "陈工厂信用贷款"
    },
    "sCP_CHAIN_personalInfo": {
        "user_subjectType": "个人",
        "user_realName": "陈雅",
        "user_cardNum": "331023198303233111",
        "person_annualIncome": "100000",
        "person_mobilePhone": "18258206611",
        "person_residenceAddr": {
            "province": "内蒙古自治区",
            "city": "呼和浩特市",
            "district": "市辖区",
            "detailedAddress": "浙江省杭州市下城区东新街道新户苑东新园(香积寺东路)"
        },
        "person_maritalStatus": "其他",
        "trustee_name": null,
        "trustee_cardNum": null,
        "trustee_residenceAddr": null,
        "trustee_isRep": "是",
        "trustee_annualIncome": null,
        "trustee_mobile": null,
        "trustee_jobTenureYears": null,
        "trustee_jobTitle": null,
        "trustee_maritalStatus": null,
        "bank_account_no": "6228480322771027112"
    },
    "sCP_CHAIN_companyInfo": null,
    "sCP_CHAIN_bankAccountInfo": [
        {
            "bank_accountName": "有限公司",
            "bank_branch": "某某分理处",
            "bank_type": "企业",
            "bank_bankCity": "市",
            "bank_bank": "中国建设银行",
            "bank_accountNum": "15622188040001301",
            "bank_bankProvince": "北京市",
            "bank_ownerType": "受托人",
            "bank_bankPhone": "13388837508"
        }
    ],
    "additional_info": {
        "jhw_loan_intRate": "0.132",
        "order_info": {
            "contract_no": "TFB000123180067",
            "contract_date": "2018/3/2015:11:51",
            "goods_name": "haha",
            "goods_marque": "7042",
            "goods_unit": "吨",
            "goods_price": "500",
            "contract_total": "1000",
            "pickup_address": "浙江省杭州市江干区天城路1号杭州东站",
            "pickup_date": "2018/3/2115:11:51",
            "transport_mode": "自由物流",
            "payment_mode": "都是",
            "bid_bound": "200",
            "bid_rate": 0.2,
            "settlement_price": "1000"
        },
        "logistics_info": {
            "logistics_company": "",
            "track_no": "",
            "delivery_date": "",
            "delivery_name": "",
            "delivery_address": "",
            "receiver_name": "",
            "receiver_address": ""
        },
        "files": {
            "purchase_contract": "http://xxx.pdf",
            "cargo_receipt": ""
        },
        "issued_confirm_info": {
            "capital_use": "塑料商品制造"
        }
    },
    "extend_trade_id": "TFB000123180067"
}
```
+ 输出
```
{
    "contentObj": {
        "code": 30000,
        "codeDesc": "internal error",
        "loanAppId": null,
        "message": "ValidateException:主库中ssn与fname与进件时不一致，主库：【ssn=331023199303233111, fname=ddd】，进件：【ssn=331023198303233111, fname=陈雅】"
    },
    "body": "{\"code\":\"30000\",\"message\":\"ValidateException:主库中ssn与fname与进件时不一致，主库：【ssn=331023199303233111, fname=ddd】，进件：【ssn=331023198303233111, fname=陈雅】\"}",
    "result": "error",
    "content": "PYCc3+ofKyXHfQ3eYhtg4YAeVKYTqem469j9GfFomNxeOSEzVXWxCv3frOXDyT904SuXEee6YLRjss1xadyur0gO3n7f9D/PWFe2/ppCJfafk+IUIuRfCX91ovhsllgJMM/TazUJlcmPuGgpZQg0vzY061ZJKsb0UfFC/EctvsFP/CywMBUUf3DzL727wNXa8aS89tIJ1aWyp3VO4pgRMlr1cImLwqO9uV7PFoeGfor4er9Ev2+joFis60ApZVULJzlYc3Ows8JqVNBANKD3DTH43Wj3gH43DBok697jPxs9INasvyYpB0oMwBUpLMqbNjZce4+z2G6fmFYnedgXHA=="
}
```

#### 查询贷款信息
+ 输入
```
{
  "loanAppId": "2010103042"
}
```
+ 输出
```
{
    "contentObj": {
        "code": 20000,
        "codeDesc": "success",
        "message": null,
        "appAmount": 1500,
        "paymentMethod": "BULLET",
        "paymentMethodDesc": "到期一次性还本付息",
        "maturity": 15,
        "maturityType": "DAILY",
        "maturityTypeDesc": "天",
        "status": "SUBMITTED",
        "statusDesc": "已提交",
        "interestDate": null,
        "rejectReason": null
    },
    "body": "{\"code\":\"20000\",\"message\":null,\"appAmount\":1500,\"paymentMethod\":\"BULLET\",\"maturity\":15,\"maturityType\":\"DAILY\",\"status\":\"SUBMITTED\",\"interestDate\":null,\"rejectReason\":null}",
    "result": "success",
    "content": "Ccy4D5PGmKr5IObio+EmDmBlSsjNstZV/XhTPCLb7ch7NYP3u5tUkuJECGfFqDUa9c9gYBQ17czD6go5KFoUIEo86S4h3Dm42PSg+3Ue/G9r1uVwXx7endYfJlXwsvgeo3oh60PDegw4lIu9H51+0vDvzon+JjL65W6UCEVktEdvIfHwcpD/ssra6DvX+koSFiHzFOfJCOQinL1uOzZ6WsHim3tFA5jZBr//jdcgxWKiCRFFegNdyJMBroGhNkW2PeggFQ9YC2MGH1FgJqnfpXQJfJiVpP4147/CbETEvLpf2BKSeM1rlYLlO90AtGlKbJe4pGmFUO/X7uTA+Je1Cg=="
}
```
#### 查询还款状态
+ 输入
```
{
  "loanAppId": "2010103042"
}
```
+ 输出
```
{
    "contentObj": {
        "code": "30000",
        "message": "ValidateException:loanId 为空",
        "repaymentInfos": null
    },
    "body": "{\"code\":\"30000\",\"message\":\"ValidateException:loanId 为空\"}",
    "result": "error",
    "content": "dUnpnaexdgyjmLT1tuy2jx3XLyyDLxvnpnbPlPtb6so38AGsurXRVy2PVwj94kUOkBEAA9Vqs77ICs0qYo83adHl9YL1vBSJadEL9fVR16Iy68MLStaN9MSLVwmyLQVw/8bBn/4/+zY95WkXVqIewZBeFyDzbGpl2keL9gqY3p476xE9DoZCd9Ib5UrAb7vSEqKacLL50fsF2IOPpw1+N9xyMB0ywWT8vHPKZk020lPWmb5E+MTY8tV6D0Drm/gOSaZePd/GI8jtiFGrlYYOuicKdPd28eOR9EeubZV2l/nXsj3zl57BEMVBRlIt2cRyZIyusLtgxuh8A4OysgkEjg=="
}
```
#### 还款界面
这个接口调用完直接拿url值，可以直接在浏览器上打开，实现免登陆
+ 输入
```
{
  "encryptPhone": "15763308887‬"
}
```
+ 输出
```
{
    "channelId": "xx",
    "nonce": "JmEmtNuo4J2dnlifirO%2FE4gFyUrLyZiWW9hrCbcl3%2F9JRYhc7BJqNX74xLP9c7XgJECW7kbcMYY%2Ffl931FfhvZUAyd5DSz6KMFvwDcvw18IoadFx7gIkrlFq1OwcHgdlTln%2Be%2FvtRgYAPp7oohClVOMaYcLKjhtij1HU4HAVi8gxy%2FdE0LJ8hFiHT4HUgYSjw9YgGFnf1SJeY37G5ebLC76C22DSKCe381Ejx%2FhC7YhDtD7evjfWBsXhXGLDRsxk0X7whNn3FVOi2ypU8rRRcbSsSsnUElA0Ab%2F%2F4315XEjsCktnrXj9OSmd58A1d8LlxKEpyZjmidS%2FOZohPymY8g%3D%3D",
    "encrypt": "MccsCWTgvx2SsvbTd5xdMlkVCi0nyaSBRgXbfpLJvUCTqrWSut%2Bp4PbQf0zhmDaR3sDRNio5zTkKLpcXZ1VsEZbg4fXbGcAtJRNa1ogrvpYkwRqkW%2Fi8%2B8hEuGB%2B7nI25bYQUD3XyI%2FDg77rYC%2BmwdOkegbCt%2FNPg5kYlnQGKgjbafgai8JpDHcl6HUOpxUe",
    "url": "https://api-demo.dianrong.com/scpgateway/api/auth/redirect?channelId=sxk0X7whNn3FVOi2ypU8rRRcbSsSsnUElA0Ab%2F%2F4315XEjsCktnrXj9OSmd58A1d8LlxKEpyZjmidS%2FOZohPymY8g%3D%I%2FDg77rYC%2BmwdOkegbCt%2FNPg5kYlnQGKgjbafgai8JpDHcl6HUOpxUe",
    "baseUrl": "https://api-demo.dianrong.com/scpgateway/api/auth/redirect"
}
```

#### 黑名单
+ 输入
```
{
  "person_realName": "陈雅",
  "person_cardNum": "33078219988880431",
  "person_mobilePhone": "15768808887"
}
```
+ 输出
```
{
    "contentObj": {
        "code": "20000",
        "message": null
    },
    "body": "{\"code\":20000,\"message\":null}",
    "result": "success",
    "content": "pRnHPxSVAuZv4U5l4XHiYzkJFkbiyTpy9wBhqH63iH8l8fjB2oWtBly2AUax3NLeEnhQIs4Ish+v/woWGVI1zDDZH79x4MwNhhJFyrwLHMdsbrK9r3aHI5p+Re3WBl9CKzAcWoamoXpaR2oHuZvZfan/0sHowI0Ygiox17aVCO95NSk9k2El6tYo+5i6RaSL4Oje/IJDYxHNoUnekIjey8uPtGDcrpzAf2akZjYnRqx6JCNnUuCYBx2+Cf0ICA4+iuba88kT+8YSwCMkUj5TrYuZfUwGyEjoXW34UnJqXUA6pRgYhQTIzOf4x/HlKblemeML4Fo9AKWS1HJnGo4ntQ=="
}
```
