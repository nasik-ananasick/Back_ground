using System;
using Background.DataBase.Context;
using Background.DataBase.Repository;
using Background.Models;

namespace Background.DataBase.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _context = new AppDbContext();
        private GenericRepository<User> _userRepository;
        private GenericRepository<Post> _postRepository;
        private GenericRepository<Reaction> _reactionRepository;
        private GenericRepository<Media> _mediaRepository;

        public GenericRepository<Media> MediaRepository
        {
            get
            {
                if (this._mediaRepository == null)
                {
                    this._mediaRepository = new GenericRepository<Media>(_context);
                }

                return _mediaRepository;
            }
        }

        public GenericRepository<User> UsersRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(_context);
                }

                return _userRepository;
            }
        }

        public GenericRepository<Post> PostsRepository
        {
            get
            {
                if (this._postRepository == null)
                {
                    this._postRepository = new GenericRepository<Post>(_context);
                }

                return _postRepository;
            }
        }

        public GenericRepository<Reaction> ReactionRepository
        {
            get
            {
                if (this._reactionRepository == null)
                {
                    this._reactionRepository = new GenericRepository<Reaction>(_context);
                }

                return _reactionRepository;
            }
        }


        // TODO добавление репозиториев для каждой таблицы

        public void Dispose() => _context.Dispose();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}