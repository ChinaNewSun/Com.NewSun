using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.NewSun.DataHelper
{
    public class Account
    {
        [Id]
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual int Age { get; set; }
        [Column(true)]
        public virtual int Flag { get; set; }
        [Ignore]
        public virtual string AgeStr
        {
            get
            {
                return "年龄：" + Age;
            }
        }
    }

    public class Test
    {
        public string connectionName = "strSqlCe";
        public DbBase CreateDbBase()
        {
            return new DbBase(connectionName);
        }

        public void Insert()//插入一条数据
        {
            
        }

        public void Query()
        { 
            //多表关联查询，返回一个表对象，但是 Posts与Users是关联关系。Post的Owner对象就是User对象。使用Post时，可以直接使用Owner指向的User对象
            // @"select * from #Posts p  left join #Users u on u.Id = p.OwnerId Order by p.Id";
            // PostWithConstructor[] data = connection.Query<PostWithConstructor, UserWithConstructor, PostWithConstructor>(sql, (post, user) => { post.Owner = user; return post; }).ToArray();

            //返回指定类型对象，例如 自定义非实体类型对象 MultipleConstructors，有两个属性 A，B。那么如下执行：
            // MultipleConstructors mult = connection.Query<MultipleConstructors>("select 0 A, 'Dapper' b").First();
            //使用：mult.A.IsEqualTo(0);      mult.B.IsEqualTo("Dapper");

            //使用参数，要求参数与传入的实体类属性必须相同
            // var car1 = new CarWithAllProps { Name = "Ford", Age = 21, Trap = Car.TrapEnum.B };
            // var car2 = connection.Query<CarWithAllProps>("select @Name Name, @Age Age, @Trap Trap", car1).First();

            //多表关联查询， 使用Read进行读取
            // var sql =@"select p.*, u.Id, u.Name + '0' Name from #Posts p left join #Users u on u.Id = p.OwnerId Order by p.Id ; select p.*, u.Id, u.Name + '0' Name from #Posts p left join #Users u on u.Id = p.OwnerId Order by p.Id";
            // var grid = connection.QueryMultiple(sql);    QueryMultiple用于多个语句的查询，
            // var data = grid.Read<Post, User, Post>((post, user) => { post.Owner = user; return post; }).ToList();   //Read一次就是读一次的。
            // var p = data.First();          p.Id.IsEqualTo(1);             p.Owner.Name.IsEqualTo("Sam" + i);

            //三个及以上表的关系，使用Read进行读取
            // var sql = @"SELECT p.* FROM #Posts p; select p.*, u.Id, u.Name + '0' Name, c.Id, c.CommentData from #Posts p left join #Users u on u.Id = p.OwnerId left join #Comments c on c.PostId = p.Idwhere p.Id = 1Order by p.Id";
            // var grid = connection.QueryMultiple(sql);
            // var post1 = grid.Read<Post>().ToList();
            // var post2 = grid.Read<Post, User, Comment, Post>((post, user, comment) => { post.Owner = user; post.Comment = comment; return post; }).SingleOrDefault();
            // post2.Comment.Id.IsEqualTo(1);
            // post2.Owner.Id.IsEqualTo(99);

            //执行存储过程，设置参数
            // var obj = new{ID = 0,Foo = "abc",Bar = 4};
            // var args = new DynamicParameters(obj);
            // args.Add("ID", 0, direction: ParameterDirection.Output);
            // connection.Execute("#TestProcWithOutParameter", args, commandType: CommandType.StoredProcedure);
            // args.Get<int>("ID").IsEqualTo(7);

            //使用事务
            // var transaction = connection.BeginTransaction();
            // transaction.Commit();
            // transaction.Rollback();


        }
    }
}
