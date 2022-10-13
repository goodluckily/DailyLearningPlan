using System.Dynamic;
using Newtonsoft.Json.Linq;
using CSRedis;
using System.Runtime.Intrinsics.Arm;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dynamic P = new DynamicInputParams();
            //P.Name = "张三";
            //P.Age = 22;
            //P.Sex = "女";
            //Console.WriteLine(P.Name);
            ////也可以添加到List集合
            //List<dynamic> List = new List<dynamic>();
            //List.Add(P);
            //foreach (var item in List)
            //{
            //    Console.WriteLine(item.Name);
            //}


            //JObject result = new JObject();
            //result.Add("","");
            //result.Add("","");


            //根据连接信息构造客户端对象
            //var redis = new CSRedis.RedisClient("127.0.0.1",6379);
            //redis中的string存取
            //redis.Set("name", "小明");
            //var name = redis.Get("name");
            //Console.WriteLine($"name={name}");

            //redis.Set("birth", DateTime.Now);
            //var birth = redis.Get("birth");
            //Console.WriteLine($"birth={birth}");

            //redis.Set("info", new { sex = "female", age = "20" });
            //var info = redis.Get("info");
            //Console.WriteLine($"info={info}");

            //Console.WriteLine("发布订阅");
            //RedisHelper.Initialization(new CSRedis.CSRedisClient("127.0.0.1:6379,defaultDatabase=0"));


            ////sub3, sub4, sub5 非争抢订阅（多端都可收到消息）
            //var sub3 = RedisHelper.SubscribeListBroadcast("list2", "sub3", msg => Console.WriteLine($"sub3 -> list2 : {msg}"));
            //var sub4 = RedisHelper.SubscribeListBroadcast("list2", "sub4", msg => Console.WriteLine($"sub4 -> list2 : {msg}"));
            //var sub5 = RedisHelper.SubscribeListBroadcast("list2", "sub5", msg => Console.WriteLine($"sub5 -> list2 : {msg}"));


            //RedisHelper.Publish("list2_sub3","1111111111111111111");
            //RedisHelper.Publish("list2","222222222222222222");
            //RedisHelper.Publish("sub3","333333333333333333");
            //RedisHelper.Publish("sub3_list2", "4444444444444444444");


            //byte a = 254;
            //a += 5;
            //Console.WriteLine(a);

            var json = "{\"store\":{\"book\":[{\"category\":\"reference\",\"author\":\"NigelRees\",\"title\":\"SayingsoftheCentury\",\"price\":8.95},{\"category\":\"fiction\",\"author\":\"EvelynWaugh\",\"title\":\"SwordofHonour\",\"price\":12.99},{\"category\":\"fiction\",\"author\":\"HermanMelville\",\"title\":\"MobyDick\",\"isbn\":\"0-553-21311-3\",\"price\":8.99},{\"category\":\"fiction\",\"author\":\"J.R.R.Tolkien\",\"title\":\"TheLordoftheRings\",\"isbn\":\"0-395-19395-8\",\"price\":22.99}],\"bicycle\":{\"color\":\"red\",\"price\":19.95}}}";

            JObject obj = JObject.Parse(json);

            //var dict = obj["store"]["book"].GroupBy(m => m["category"]).ToDictionary(k => k.Key,v => v.Select(n => n.Value<decimal>("price")).Sum());

            //foreach (var key in dict.Keys)
            //{
            //    Console.WriteLine($"key={key},value={dict[key]}");
            //}

            //https://www.newtonsoft.com/json/help/html/QueryJsonSelectTokenJsonPath.htm
            
            //var priceList = obj.SelectTokens("$..price");

            ////JSONPath
            //foreach (var price in priceList)
            //{
            //    Console.WriteLine(price.Value<decimal>());
            //}

        }
    }

    class DynamicInputParams : DynamicObject
    {
        Dictionary<string, object> property = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            return property.TryGetValue(name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            property[binder.Name] = value;
            return true;
        }
    }
}