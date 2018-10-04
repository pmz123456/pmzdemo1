using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using Nest;
using PlainElastic.Net;
using PlainElastic.Net.Queries;
using PlainElastic.Net.Serialization;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;
using ServiceStack.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{

    static class Program
    {

        private static object locker = new object();
        static int money = 10000;
        private static int count = 0;
        static void Main(string[] args)
        {
            #region
            //Thread t1 = new Thread(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        counter++;
            //        Thread.Sleep(1);
            //    }
            //});
            //t1.Start();

            //Thread t2 = new Thread(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        counter++;
            //        Thread.Sleep(1);
            //    }
            //});
            //t2.Start();
            //t1.Join();

            //t2.Join();

            //Console.WriteLine(counter);
            #endregion

            #region
            //Thread t1 = new Thread(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        counter++;
            //        Console.WriteLine(counter);
            //    }
            //});
            //t1.Start();
            //Thread t2 = new Thread(() =>
            //{
            //    t1.Join();
            //    for (int i = 0; i < 100; i++)
            //    {
            //        counter++;
            //        Console.WriteLine(counter);
            //    }
            //});
            //t2.Start();

            #endregion

            #region
            //Thread t1 = new Thread(() =>
            //{

            //    for (int i = 0; i < 1000; i++)
            //    {
            //        QuQian("t1");

            //    }
            //});
            //Thread t2 = new Thread(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        QuQian("t2");

            //    }
            //});
            //t1.Start();
            //t2.Start();

            #endregion

            #region

            //AutoResetEvent mre = new AutoResetEvent(false);

            //Thread t1 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("开始等着开门");
            //        mre.WaitOne(5000);
            //        Console.WriteLine("终于等到你");
            //    }
            //});
            //t1.Start();
            //Console.WriteLine("按任意键开门");
            //Console.ReadKey();
            //mre.Set();

            //Console.WriteLine("按任意键开门");
            //Console.ReadKey();
            //mre.Set();

            //Console.ReadKey();
            //mre.Reset();

            #endregion

            #region 
            //MemcachedClientConfiguration mcConfig = new MemcachedClientConfiguration();
            //mcConfig.AddServer("127.0.0.1:11211");//必须指定端口
            //using (MemcachedClient client = new MemcachedClient(mcConfig))
            //{
            //    client.Remove("pmz");
            //    object Name;
            //    if (!client.TryGet("pmz", out Name))
            //    {

            //        Console.WriteLine("未找到");
            //        client.Store(Enyim.Caching.Memcached.StoreMode.Set, "pmz", "yzk", TimeSpan.FromSeconds(5000));
            //        Console.WriteLine("添加成功");

            //    }
            //    else
            //    {

            //        Console.WriteLine(Name);
            //    }



            //}

            #endregion

            #region
            //MemcachedClientConfiguration mcConfig = new MemcachedClientConfiguration();
            //mcConfig.AddServer("127.0.0.1:11211");//必须指定端口
            //using (MemcachedClient client = new MemcachedClient(mcConfig))
            //{

            //    var cas = client.GetWithCas("Name");
            //    Console.WriteLine("按任意键继续");
            //    Console.ReadKey();
            //    var res = client.Cas(Enyim.Caching.Memcached.StoreMode.Set, "Name", cas.Result + "1",
            //    cas.Cas);
            //    if (res.Result)
            //    {
            //        Console.WriteLine("修改成功");
            //    }
            //    else
            //    {
            //        Console.WriteLine("被别人修改了");
            //    }

            //}
            #endregion


            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379"))
            {
                IDatabase db = redis.GetDatabase();//默认是访问 db0 数据库，可以通过方法参数指定数
                db.SetAdd("age", 18);
                string s = db.StringGetAsync("Name").Result;
                if (s == null)
                {
                    db.StringSetAsync("Name", "abc", TimeSpan.FromSeconds(5000));

                    db.StringAppend("Name", "abcdee");


                }
                else
                {
                   
                    Console.WriteLine(s);
                    db.KeyDelete("Name");

                }
                Console.ReadKey();
            }
        }
        static Task<string> F2Async()
        {
            return Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                return "F2";
            });
        }
        //[MethodImpl(MethodImplOptions.Synchronized)]
        static void QuQian(string name)
        {
            Monitor.Enter(locker);
            try
            {

                Console.WriteLine(name + "查看一下余额" + money);
                int yue = money - 1;
                Console.WriteLine(name + "取钱");
                money = yue;//故意这样写，写成 money--其实就没问题
                Console.WriteLine(name + "取完了，剩" + money);

            }
            finally
            {
                Monitor.Exit(locker);
            }

        }
    }

    class God
    {
        //private static God instance = new God();
        private static God instance = null;
        private God()
        {

        }
        public static God GetInstance()
        {
            if (instance == null)
            {
                instance = new God();
            }
            return instance;

        }


    }




}