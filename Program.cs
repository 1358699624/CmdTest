using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using NSQLFormatter;
namespace 命令窗口
{
    class Program
    {
        public record Person(string FirstName, string LastName, string[] PhoneNumbers);

        public record Person2(string FirstName, string LastName);
        static void Main(string[] args)
        {
            Console.WriteLine(NSQLFormatter.Formatter.Format(@"SELECT   a.ID, a.ACE001, a.ACE002, a.ACE014, a.ABA004, a.ACE004, a.ACD302, a.AAD101, a.AAA008, a.AAA009, a.AAA010, 
                a.ACE006, a.ACE005, a.ACE007, a.MEMO, a.CREATED, a.AUTHOR, a.MODIFIED, a.EDITOR, a.ACE022, a.AAA308, 
                a.AAA309, a.AAA307, a.AAA118, b.ACE011, b.ACE012
FROM      dbo.AE01 AS a LEFT OUTER JOIN
                dbo.AE02 AS b ON a.ID = b.AAE006"));

            Person2 person = new("Nancy", "Davolio");
            Console.WriteLine(person); // output: Person { FirstName = Nancy, LastName = Davolio }

            var phoneNumbers = new string[2];
            Person person1 = new("Nancy", "Davolio", phoneNumbers);
            Person person2 = new("Nancy", "Davolio", phoneNumbers);
            Console.WriteLine(person1 == person2); // output: True

            person1.PhoneNumbers[0] = "555-1234";
            Console.WriteLine(person1 == person2); // output: True



            string b = null;
            if (b is not null)
            {
                Console.WriteLine(b); // output: False
            }
            if (b is null)
            {
                Console.WriteLine($"{person1.PhoneNumbers[0]}"); // output: False
            }
            Console.WriteLine(ReferenceEquals(person1, person2)); // output: False


            PrintDelegate pd = (string str) =>
            {
                System.Console.WriteLine("Printing...{0}", str);
                System.Console.WriteLine("Content:{0}", str);
            };
            pd("The quick brown fox jumps oyer a lazy dog.");



            Action<string> action = proint;

            var res = Task.Run(() => action.Invoke("321456987"));//开启线程



            var startingdeck = from s in Suits()

                               from r in Ranks()
                               select new { Suit = s, Rank = r };

            foreach (var card in startingdeck)
            {
                Console.WriteLine(card);
            }


            foreach (int item in power(2, 8))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine( MyEnum.D);
            Console.WriteLine((int)MyEnum.D);

            Console.WriteLine((int)Permission.Delete);

            Console.WriteLine(Permission.Create);

            Console.WriteLine((int)Permission.Create);//8

            var parmission = Permission.Create | Permission.Read | Permission.Update | Permission.Delete;
            Console.WriteLine(parmission);


            #region 多态

            Major major1 = new under();
            major1.Id = 1;
            major1.Name = "张晓";
            Console.WriteLine("本科生信息：");
            Console.WriteLine("学号：" + major1.Id + "姓名：" + major1.Name);
            major1.Requirement();
            Major major2 = new Gradual();
            major2.Id = 2;
            major2.Name = "李明";
            Console.WriteLine("研究生信息：");
            Console.WriteLine("学号：" + major2.Id + "姓名：" + major2.Name);
            major2.Requirement();

            #endregion

            #region 泛型

            List<string> list = new();
            list.Add("1");
            list.Add("2");
            for (int i = 0; i < list.Count; i++)
              {
                Console.WriteLine(list[i]);
               }
            #endregion
            Console.ReadLine();
        }
        public delegate void PrintDelegate(string content);

        public async Task<int> yibu() {

            return 10;
        }

        public static IEnumerable<int> power(int a, int b)
        {

            int c = 1;
            for (int i = 0; i < b; i++)
            {
                c = a * c;
                yield return c;
            }
        }

        //枚举
        enum MyEnum
        {
            D,
            c
        }

        //枚举
        [Flags]
        enum Permission
        {
            Unknown = 0, // 也可以写成0x00或0　　　　　　　

            Create = 1 << 0, // 0x01或1　　　　　　　　　　　

            Read = 1 << 1,  //0x02或2

            Update = 1 << 2, //0x04或4

            Delete = 1 << 3  //0x08或8

        }

        public static void proint(string Date_Time)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(DateTime.Now.ToShortDateString() + i);
            }
        }
        // Program.cs
        // The Main() method


        //LINQ
        static IEnumerable<string> Suits()
        {
            yield return "红桃";
            yield return "黑桃";
            yield return "方块";
            yield return "梅花";
        }

        static IEnumerable<string> Ranks()
        {
            yield return "2";
            yield return "3";
            yield return "4";
            yield return "5";
            yield return "6";
            yield return "7";
            yield return "8";
            yield return "9";
            yield return "10";
            yield return "J";
            yield return "Q";
            yield return "K";
            yield return "A";
        }

    }

    #region 多态

    abstract class Major 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract void Requirement();
    }

    class under : Major 
    {
        public override void Requirement() 
        {
            Console.WriteLine("本科生学制4年，必须修满48学分");
        
        }
    }
    class Gradual : Major
    {
        public override void Requirement()
        {
            Console.WriteLine("研究生学制3年，必须修满32学分");

        }
    }
    #endregion
}