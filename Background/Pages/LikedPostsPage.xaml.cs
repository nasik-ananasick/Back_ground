using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Background.DataBase.UnitOfWork;
using Background.Models;

namespace Background.Pages
{
    public partial class LikedPostsPage : Page
    {
        private ObservableCollection<Post> Posts { get; set; }
        private ObservableCollection<TimeLinePost> TimeLinePosts { get; set; }
        private ObservableCollection<TimeLinePost> _tempPosts;

        public LikedPostsPage()
        {
            InitializeComponent();
            TimeLinePosts = new ObservableCollection<TimeLinePost>();
            _tempPosts = new ObservableCollection<TimeLinePost>();
            using (var unitOfWork = new UnitOfWork())
            {
                var user = unitOfWork.UsersRepository.GetWithInclude(x => x.Id == Account.Id, x => x.Reactions)
                    .FirstOrDefault();
                if (user != null)
                {
                    var reactions = user.Reactions.Where(x => x.IsLike).ToList();
                    foreach (var reaction in reactions)
                    {
                        var post = unitOfWork.PostsRepository
                            .GetWithInclude(x => x.Id == reaction.PostId, x => x.User.Media, x => x.Media)
                            .FirstOrDefault();
                        if (post != null)
                        {
                            var timeLinePost = new TimeLinePost(post);
                            timeLinePost.LikeImage = (BitmapImage)FindResource("LikeEnabledIcon");
                            TimeLinePosts.Add(timeLinePost);
                        }
                    }
                }

                ListBoxPosts.ItemsSource = TimeLinePosts;
            }
        }

        private void CommandLike_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var button = sender as Button;
            var postId = button?.CommandParameter is Guid guid ? guid : default;
            if (postId == default) return;
            using (var unitOfWork = new UnitOfWork())
            {
                var reaction = unitOfWork.ReactionRepository
                    .GetWithInclude(x => x.PostId == postId, x => x.User)
                    .FirstOrDefault(x => x.User.Id == Account.Id);
                if (reaction != null)
                {
                    reaction.IsLike = false;
                }

                unitOfWork.ReactionRepository.Update(reaction);
                var post = unitOfWork.PostsRepository.Get(postId);
                post.LikesCount--;
                unitOfWork.PostsRepository.Update(post);
            }

            var timeLinePost = TimeLinePosts.FirstOrDefault(x => x.Id == postId);
            if (timeLinePost != null)
            {
                TimeLinePosts.Remove(timeLinePost);
                _tempPosts.Remove(timeLinePost);
            }

            ListBoxPosts.ItemsSource = TimeLinePosts;
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchTextBox.Text;
            if (searchText.Equals("Поиск")) return;
            if (string.IsNullOrEmpty(searchText))
            {
                ListBoxPosts.ItemsSource = TimeLinePosts;
                return;
            }

            if (searchText.Length > 0)
            {
                _tempPosts = new ObservableCollection<TimeLinePost>(TimeLinePosts.Where(x =>
                    x.AccountName.Contains(searchText) || x.Tags.Contains(searchText)));

                ListBoxPosts.ItemsSource = _tempPosts;
            }
            else
            {
                ListBoxPosts.ItemsSource = Posts;
            }
        }
    }
}