using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Background.DataBase.UnitOfWork;
using Background.Models;
using Microsoft.Win32;

namespace Background.Pages
{
    public class TimeLinePost : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string Post { get; set; }
        public string AccountImage { get; set; }
        public string AccountName { get; set; }
        public string Tags { get; set; }
        private int _likes;

        public int Likes
        {
            get => _likes;
            set
            {
                _likes = value;
                OnPropertyChanged("Likes");
            }
        }

        private ImageSource _likeImage;

        public ImageSource LikeImage
        {
            get => _likeImage;
            set
            {
                _likeImage = value;
                OnPropertyChanged("LikeImage");
            }
        }

        public TimeLinePost()
        {
        }

        public TimeLinePost(Post post)
        {
            Id = post.Id;
            Post = post.Media.ImagePath;
            AccountImage = post.User.Media.ImagePath;
            AccountName = post.User.NickName;
            Likes = post.LikesCount;
            Tags = post.Tags;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class TimelinePage : Page
    {
        private ObservableCollection<Post> Posts { get; set; }
        private ObservableCollection<TimeLinePost> TimeLinePosts { get; set; }
        private ObservableCollection<TimeLinePost> _tempPosts;

        public TimelinePage()
        {
            InitializeComponent();
            TimeLinePosts = new ObservableCollection<TimeLinePost>();
            _tempPosts = new ObservableCollection<TimeLinePost>();
            using (var unitOfWork = new UnitOfWork())
            {
                Posts = new ObservableCollection<Post>(
                    unitOfWork.PostsRepository.GetWithInclude(x => x.UserId != Account.Id, x => x.User.Media,
                        x => x.Media));
                foreach (var post in Posts)
                {
                    var timeLinePost = new TimeLinePost(post);
                    var reaction = unitOfWork.ReactionRepository
                        .GetWithInclude(x => x.PostId == post.Id, x => x.User)
                        .FirstOrDefault(x => x.User.Id == Account.Id);
                    if (reaction != null && reaction.IsLike)
                        timeLinePost.LikeImage = (BitmapImage)FindResource("LikeEnabledIcon");
                    else
                    {
                        timeLinePost.LikeImage = (BitmapImage)FindResource("LikeDesabledIcon");
                    }

                    TimeLinePosts.Add(timeLinePost);
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
                var post = unitOfWork.PostsRepository.GetWithInclude(x => x.Id == postId, x => x.User.Media,
                    x => x.Media).FirstOrDefault();
                var reaction = unitOfWork.ReactionRepository
                    .GetWithInclude(x => x.PostId == postId, x => x.User)
                    .FirstOrDefault(x => x.User.Id == Account.Id);
                var user = unitOfWork.UsersRepository.Get(Account.Id);
                if (reaction == null)
                {
                    reaction = new Reaction
                    {
                        Id = Guid.NewGuid(),
                        PostId = postId,
                        User = user,
                        IsLike = true,
                    };
                    unitOfWork.ReactionRepository.Create(reaction);
                    post.LikesCount++;
                }
                else
                {
                    if (reaction.IsLike)
                    {
                        reaction.IsLike = false;
                        reaction.User = user;
                        unitOfWork.ReactionRepository.Update(reaction);
                        post.LikesCount--;
                    }
                    else
                    {
                        reaction.IsLike = true;
                        reaction.User = user;
                        unitOfWork.ReactionRepository.Update(reaction);
                        post.LikesCount++;
                    }
                }

                var timeLinePost = TimeLinePosts.FirstOrDefault(x => x.Id == postId);
                if (timeLinePost != null)
                {
                    if (reaction.IsLike)
                        timeLinePost.LikeImage = (BitmapImage)FindResource("LikeEnabledIcon");
                    else
                    {
                        timeLinePost.LikeImage = (BitmapImage)FindResource("LikeDesabledIcon");
                    }

                    timeLinePost.Likes = post.LikesCount;
                }

                unitOfWork.PostsRepository.Update(post);
            }
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchTextBox.Text;
            if(searchText.Equals("Поиск")) return;
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