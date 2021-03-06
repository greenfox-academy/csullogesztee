﻿using Reddit.Models;
using Reddit.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.Services
{
    public class RedditService
    {
        public RedditRepository redditRepository;

        public RedditService(RedditRepository redditRepository)
        {
            this.redditRepository = redditRepository;
        }

        public bool IdValidation(long id)
        {
            return redditRepository.ValidId(id);
        }

        public void VoteDown(long id, string name)
        {
            redditRepository.DownVote(id,name);
        }

        public List<Post> ListOfPosts()
        {
            return redditRepository.GetPosts();
        }

        public void VoteUp(long id, string name)
        {
            redditRepository.UpVote(id, name);
        }

        public Post CreatePost(PostCreator postCreator)
        {
            return redditRepository.AddPost(postCreator);
        }
    }
}
