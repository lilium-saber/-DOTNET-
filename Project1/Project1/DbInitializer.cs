using Project1.Modal;

namespace Project1
{
    public static class DbInitializer
    {
        public static void Initialize(SqlNetWork context)
        {
            if(context.users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User{UserName="admin",UserPassWord="123",CreateUserDate=System.DateTime.Now}
            };

            context.users.AddRange(users);
            context.SaveChanges();

            var textEssayTypes = new TextEssayType[]
            {
                new TextEssayType{EssayNub="0001",EssayType="Text",AddTextDate=System.DateTime.Now}
            };

            context.textEssayTypes.AddRange(textEssayTypes);
            context.SaveChanges();  

            var liuyans = new SetLiuYan[]
            {
                new SetLiuYan{UserName="admin",LiuYanTitle="Test",LiuYanText="Test",UserHome="Test",LiuYanAnesw="Test",LiuYanDate=System.DateTime.Now}
            };

            context.liuYans.AddRange(liuyans);
            context.SaveChanges();

            var pinluns = new PingLun[]
            {
                new PingLun{UserName="admin",PingLunText="Test",PingLunDate=System.DateTime.Now}
            };

            context.pingLuns.AddRange(pinluns);
            context.SaveChanges();

            var essayHires = new EssayHire[]
            {
                new EssayHire{HireNum="0001",HireAddress="/",HireDate=System.DateTime.Now}
            };

            context.essayHires.AddRange(essayHires);
            context.SaveChanges();

            var essays = new Essay[]
            {
                new Essay{EssayPingLunNum=0,EssayPropularity=5,EssayText="Test",EssayDate=System.DateTime.Now,EssayTitle="test",EssayType="TEXT",ShortWord="0",PingLuns=pinluns}
            };

            context.Essays.AddRange(essays);
            context.SaveChanges();


        }
    }
}
