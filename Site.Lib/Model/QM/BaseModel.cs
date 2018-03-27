namespace Site.Lib.Model.QM
{
    public class ReqTest
    {
        public string Type { get; set; }
       public  BaseModel Model{get;set;}
    }
    public class BaseModel
    {
        // public int Type { get; set; }
        public string Id { get; set; }
    }
    public class ChildModel:BaseModel
    {
        public string Id1 { get; set; }
    }
    public class Child2Model:BaseModel
    {
        public string Id2 { get; set; }
    }
}