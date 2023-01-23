using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Console.Utils
{
    public class MySerializer
    {
        public void Test()
        {
            try
            {
                var Json = "{\r\n\t\t\t\"AAA\":{\"21\":1.120161363,\"42\":1.138817672,\"63\":1.152628171,\"126\":1.150187223,\"252\":1.154285672,\"378\":1.169898646,\"504\":1.189210302,\"630\":1.208032937,\"756\":1.226276858,\"882\":1.245529496},\r\n\t\t\t\"AA\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"A\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"BBB\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"BB\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"B\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"CCC\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"CC\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"C\":{\"21\":0.05,\"45\":0.05}\r\n\t\t}";
                var Json2 = "{\r\n\t\t\"ADDITIVE\":\r\n\t\t{\r\n\t\t\t\"AAA\":{\"21\":1.120161363,\"42\":1.138817672,\"63\":1.152628171,\"126\":1.150187223,\"252\":1.154285672,\"378\":1.169898646,\"504\":1.189210302,\"630\":1.208032937,\"756\":1.226276858,\"882\":1.245529496},\r\n\t\t}\r\n\t}";
                var Json3 = "{\r\n\t\"TRADE_DATE\":\r\n\t{\r\n\t\t\"ADDITIVE\":\r\n\t\t{\r\n\t\t\t\"AAA\":{\"21\":1.120161363,\"42\":1.138817672,\"63\":1.152628171,\"126\":1.150187223,\"252\":1.154285672,\"378\":1.169898646,\"504\":1.189210302,\"630\":1.208032937,\"756\":1.226276858,\"882\":1.245529496},\r\n\t\t}\r\n\t}\r\n}";
                var Json4 = "{\r\n\t\"TRADE_DATE\":\r\n\t{\r\n\t\t\"ADDITIVE\":\r\n\t\t{\r\n\t\t\t\"AAA\":{\"21\":1.120161363,\"42\":1.138817672,\"63\":1.152628171,\"126\":1.150187223,\"252\":1.154285672,\"378\":1.169898646,\"504\":1.189210302,\"630\":1.208032937,\"756\":1.226276858,\"882\":1.245529496},\r\n\t\t\t\"AA\":\r\n\t\t\t{\r\n\t\t\t\t\"21\":0.05,\r\n\t\t\t\t\"45\":0.05\r\n\t\t\t},\r\n\t\t\t\"A\":\r\n\t\t\t{\r\n\t\t\t\t\"21\":0.05,\r\n\t\t\t\t\"45\":0.05\r\n\t\t\t},\r\n\t\t\t\"BBB\":\r\n\t\t\t{\r\n\t\t\t\t\"21\":0.05,\r\n\t\t\t\t\"45\":0.05\r\n\t\t\t},\r\n\t\t\t\"BB\":\r\n\t\t\t{\r\n\t\t\t\t\"21\":0.05,\r\n\t\t\t\t\"45\":0.05\r\n\t\t\t},\r\n\t\t\t\"B\":\r\n\t\t\t{\r\n\t\t\t\t\"21\":0.05,\r\n\t\t\t\t\"45\":0.05\r\n\t\t\t},\r\n\t\t\t\"CCC\":\r\n\t\t\t{\r\n\t\t\t\t\"21\":0.05,\r\n\t\t\t\t\"45\":0.05\r\n\t\t\t},\r\n\t\t\t\"CC\":\r\n\t\t\t{\r\n\t\t\t\t\"21\":0.05,\r\n\t\t\t\t\"45\":0.05\r\n\t\t\t},\r\n\t\t\t\"C\":\r\n\t\t\t{\r\n\t\t\t\t\"21\":0.05,\r\n\t\t\t\t\"45\":0.05\r\n\t\t\t}\r\n\t\t},\r\n\t\t\"PERCENTUAL\":\r\n\t\t{\r\n\t\t\t\"AAA\":{\"21\":1.120161363,\"42\":1.138817672,\"63\":1.152628171,\"126\":1.150187223,\"252\":1.154285672,\"378\":1.169898646,\"504\":1.189210302,\"630\":1.208032937,\"756\":1.226276858,\"882\":1.245529496},\r\n\t\t\t\"AA\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"A\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"BBB\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"BB\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"B\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"CCC\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"CC\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"C\":{\"21\":0.05,\"45\":0.05}\r\n\t\t}\r\n\t},\r\n\t\"REFERENCE_DATE\":\r\n\t{\r\n\t\t\"ADDITIVE\":\r\n\t\t{\r\n\t\t\t\"AAA\":{\"21\":1.120161363,\"42\":1.138817672,\"63\":1.152628171,\"126\":1.150187223,\"252\":1.154285672,\"378\":1.169898646,\"504\":1.189210302,\"630\":1.208032937,\"756\":1.226276858,\"882\":1.245529496},\r\n\t\t\t\"AA\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"A\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"BBB\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"BB\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"B\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"CCC\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"CC\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"C\":{\"21\":0.05,\"45\":0.05}\r\n\t\t},\r\n\t\t\"PERCENTUAL\":\r\n\t\t{\r\n\t\t\t\"AAA\":{\"21\":1.120161363,\"42\":1.138817672,\"63\":1.152628171,\"126\":1.150187223,\"252\":1.154285672,\"378\":1.169898646,\"504\":1.189210302,\"630\":1.208032937,\"756\":1.226276858,\"882\":1.245529496},\r\n\t\t\t\"AA\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"A\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"BBB\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"BB\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"B\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"CCC\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"CC\":{\"21\":0.05,\"45\":0.05},\r\n\t\t\t\"C\":{\"21\":0.05,\"45\":0.05}\r\n\t\t}\r\n\t}\r\n}";
                var jsonString = JsonConvert.DeserializeObject<ADDITIVE>(Json);
                var jsonString2 = JsonConvert.DeserializeObject<TRADE_DATE>(Json2);
                var jsonString3 = JsonConvert.DeserializeObject<model>(Json3);
                var item2 = "ADDITIVE";
                var item3 = "AAA";

                var tradeDate = jsonString3.TRADE_DATE;
                var additiveOrPercentual = tradeDate.GetType().GetProperty(item2).GetValue(tradeDate);
                var propSpreadClass = additiveOrPercentual.GetType().GetProperty(item3).GetValue(additiveOrPercentual);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

    public class model
    {
        public TRADE_DATE TRADE_DATE { get; set; }
    }

    public class TRADE_DATE
    {
        public ADDITIVE ADDITIVE { get; set; }
    }

    public class ADDITIVE
    {
        public Dictionary<string, double> AAA { get; set; }
        public Dictionary<string, double> AA { get; set; }
        public Dictionary<string, double> A { get; set; }
        public Dictionary<string, double> BBB { get; set; }
        public Dictionary<string, double> BB { get; set; }
        public Dictionary<string, double> B { get; set; }
        public Dictionary<string, double> CCC { get; set; }
        public Dictionary<string, double> CC { get; set; }
        public Dictionary<string, double> C { get; set; }
    }
}
