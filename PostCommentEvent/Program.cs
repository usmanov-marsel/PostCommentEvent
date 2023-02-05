using System.Text.Json;
using System.Text.Json.Serialization;
using TestPost.Models;

namespace PostCommentEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 700;

            var user1 = new User { FirstName = "Tamara", LastName = "Sidorova" };
            var user2 = new User { FirstName = "Vladislav", LastName = "Petrov" };
            var user3 = new User { FirstName = "Roman", LastName = "Demidov" };

            var users = new List<User> { user1, user2, user3 };

            for (int i = 0; i < users.Count; i++)
            {
                users[i].Id = i;
            }

            Console.WriteLine("Создание пользователей");
            Console.WriteLine("user1: " + user1);
            Console.WriteLine("user2: " + user2);
            Console.WriteLine("user3: " + user3);
            Console.WriteLine("===============");

            var post1 = new Post { Content = "bla bla bla", Preview = "./img/preview1.png" };
            var post2 = new Post { Content = "la la la la", Preview = "./img/preview2.png" };
            var post3 = new Post { Content = "zu zu zu zu", DateOfCreation = new DateTime(2023, 1, 1) };
            var post4 = new Post { Content = "ga ga gag a" };

            var posts = new List<Post> { post1, post2, post3, post4 };

            for (int i = 0; i < posts.Count; i++)
            {
                posts[i].Id = i;
            }

            var comment1 = new Comment { Content = "very cool", DateOfCreation = new DateTime(2023, 2, 1) };
            var comment2 = new Comment { Content = "beatiful" };
            var comment3 = new Comment { Content = "great!!!!!" };

            var comments = new List<Comment> { comment1, comment2, comment3 };

            for (int i = 0; i < comments.Count; i++)
            {
                comments[i].Id = i;
            }

            var event1 = new CollectiveEvent { DateOfEvent = new DateTime(2023, 2, 23), Title = "23 febrary", Description = "Defender of the Fatherland Day", NecessaryNumberPerson = 2 };
            var event2 = new CollectiveEvent { DateOfEvent = new DateTime(2023, 2, 28), Title = "8 marth", NecessaryNumberPerson = 10 };

            var collectiveEvents = new List<CollectiveEvent> { event1, event2 };

            for (int i = 0; i < collectiveEvents.Count; i++)
            {
                collectiveEvents[i].Id = i;
            }

            user1.CreatePost(post1);
            user1.CreatePost(post2);
            user1.CreatePost(post3);
            user2.CreatePost(post4);

            Console.WriteLine("Создание постов");
            Console.WriteLine("post1: " + post1);
            Console.WriteLine("post2: " + post2);
            Console.WriteLine("post3: " + post3);
            Console.WriteLine("post4: " + post4);
            Console.WriteLine("===============");

            user3.CreateCommentInPost(comment1, post1);
            user1.CreateCommentInPost(comment2, post1);
            user2.CreateCommentInPost(comment3, post4);

            Console.WriteLine("Создание комментариев");
            Console.WriteLine("comment1: " + comment1);
            Console.WriteLine("comment2: " + comment2);
            Console.WriteLine("comment3: " + comment3);
            Console.WriteLine("===============");

            event1.AddParticipant(user2);
            event1.AddParticipant(user3);
            event2.AddParticipant(user1);

            Console.WriteLine("Добавление участников в мероприятия");
            Console.WriteLine("event1: " + event1);
            Console.WriteLine("event2: " + event2);
            Console.WriteLine("===============");

            Console.WriteLine("Просмотр сколько дней назад был сделан пост:");
            Console.WriteLine("post1 " + post1.GetNumberPastDays() + " days ago");
            Console.WriteLine("post2 " + post2.GetNumberPastDays() + " days ago");
            Console.WriteLine("post3 " + post3.GetNumberPastDays() + " days ago");
            Console.WriteLine("post4 " + post4.GetNumberPastDays() + " days ago");
            Console.WriteLine("===============");

            Console.WriteLine("Проверка сколько дней назад был сделан пост с 31 января 2023");
            Console.WriteLine("post1 " + post1.GetNumberPastDaysFrom(new DateTime(2023, 1, 31)) + " days ago");
            Console.WriteLine("post2 " + post2.GetNumberPastDaysFrom(new DateTime(2023, 1, 31)) + " days ago");
            Console.WriteLine("post3 " + post3.GetNumberPastDaysFrom(new DateTime(2023, 1, 31)) + " days ago");
            Console.WriteLine("post4 " + post4.GetNumberPastDaysFrom(new DateTime(2023, 1, 31)) + " days ago");
            Console.WriteLine("===============");

            Console.WriteLine("Просмотр сколько дней назад был сделан комментарий:");
            Console.WriteLine("comment1 " + comment1.GetNumberPastDays() + " days ago");
            Console.WriteLine("comment2 " + comment2.GetNumberPastDays() + " days ago");
            Console.WriteLine("comment3 " + comment3.GetNumberPastDays() + " days ago");
            Console.WriteLine("===============");

            Console.WriteLine("Состоятся ли меропрития?:");
            Console.WriteLine(event1.isEventHappen() ? "event 1: YES" : "event 1: NO");
            Console.WriteLine(event2.isEventHappen() ? "event 2: YES" : "event 2: NO");
            Console.WriteLine("===============");

            Console.WriteLine("Вывод полной информации о классах: ");
            var options = new JsonSerializerOptions { WriteIndented = true, ReferenceHandler = ReferenceHandler.IgnoreCycles };
            Console.WriteLine("Пользователи: " + JsonSerializer.Serialize(users, options));
            Console.WriteLine("===============");
            Console.WriteLine("Посты:" + JsonSerializer.Serialize(posts, options));
            Console.WriteLine("===============");
            Console.WriteLine("Комментарии:" + JsonSerializer.Serialize(comments, options));
            Console.WriteLine("===============");
            Console.WriteLine("Мероприятия: " + JsonSerializer.Serialize(collectiveEvents, options));
        }
    }
}