using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class FriendAddView
    {
        FriendService friendService = new FriendService();

        public void Show(User user)
        {            
            FriendAddData friendAddData = new FriendAddData();

            Console.WriteLine("Введите электронную почту пользователя для добавления в друзья");
            friendAddData.friend_email = Console.ReadLine();

            friendAddData.user_id = user.Id;

            // Доработать
            try
            {
                friendService.AddFrend(friendAddData);
                SuccessMessage.Show("Друг добавлен");
            }
            catch
            {
                AlertMessage.Show("Произошла ошибка");
            }
        }
    }
}
