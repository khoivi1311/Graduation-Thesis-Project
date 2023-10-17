using learn_programming_services.Businesses.Functions.Discussions;
using learn_programming_services.Database.Entity;
using learn_programming_services.Database.Repository;
using learn_programming_services.Utils;

namespace learn_programming_services.Businesses.Services
{
    public class DiscussionsServices : IDiscussionsServices
    {
        private readonly IDiscussionsRepository _discussionsRepository;
        private readonly IDiscussionCommentsServices _discussionCommentsServices;
        private readonly IDiscussionReplyCommentsServices _discussionReplyCommentsServices;
        private readonly IDiscussionCommentActionsServices _discussionCommentActionsServices;
        private readonly IDiscussionReplyCommentActionsServices _discussionReplyCommentActionsServices;
        private readonly IUsersServices _usersServices;
        private readonly ICommonUtil _commonUtil;

        public DiscussionsServices(IDiscussionsRepository discussionsRepository,
            IDiscussionCommentsServices discussionCommentsServices,
            IDiscussionReplyCommentsServices discussionReplyCommentsServices,
            IDiscussionCommentActionsServices discussionCommentActionsServices,
            IDiscussionReplyCommentActionsServices discussionReplyCommentActionsServices,
            IUsersServices usersServices,
            ICommonUtil commonUtil)
        {
            _discussionsRepository = discussionsRepository;
            _discussionCommentsServices = discussionCommentsServices;
            _discussionReplyCommentsServices = discussionReplyCommentsServices;
            _discussionCommentActionsServices = discussionCommentActionsServices;
            _discussionReplyCommentActionsServices = discussionReplyCommentActionsServices;
            _usersServices = usersServices;
            _commonUtil = commonUtil;
        }

        public async Task<ICreateNewDiscussionFunction.Response> CreateNewDiscussion(ICreateNewDiscussionFunction.Request request)
        {
            Discussions discussion = new Discussions()
            {
                Name = request.discussion.discussionName.Trim(),
                Content = request.discussion.content.Trim(),
                Description = request.discussion.description.Trim(),
                Image = request.discussion.image.Trim(),
                IsDeleted = false,
                AuthorId = request.discussion.userId,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            await _discussionsRepository.createNewDiscussion(discussion);

            return new ICreateNewDiscussionFunction.Response(true, null);
        }

        public async Task<ICreateNewDiscussionCommentFunction.Response> CreateNewDiscussionComment (ICreateNewDiscussionCommentFunction.Request request)
        {
            var discussion = await _discussionsRepository.findDiscussionById(request.discussionComment.discussionId);

            if (discussion != null && discussion.IsDeleted.Equals(false))
            {
                DiscussionComments discussionComment = new DiscussionComments()
                {
                    Content = request.discussionComment.content.Trim(),
                    IsDeleted = false,
                    DiscussionId = discussion.Id,
                    AuthorId = request.discussionComment.userId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                await _discussionCommentsServices.CreateNewDiscussionComment(discussionComment);

                return new ICreateNewDiscussionCommentFunction.Response(true, null);
            }

            return new ICreateNewDiscussionCommentFunction.Response(false, "This discussion does not exist");
        }

        public async Task<ICreateNewDiscussionReplyCommentFunction.Response> CreateNewDiscussionReplyComment(ICreateNewDiscussionReplyCommentFunction.Request request)
        {
            var discussionComment = await _discussionCommentsServices.FindDiscussionCommentById(request.discussionReplyComment.discussionCommentId);

            if (discussionComment != null && discussionComment.IsDeleted.Equals(false))
            {
                DiscussionReplyComments discussionReplyComment = new DiscussionReplyComments()
                {
                    Content = request.discussionReplyComment.content.Trim(),
                    IsDeleted = false,
                    DiscussionCommentId = discussionComment.Id,
                    AuthorId = request.discussionReplyComment.userId,
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                };

                await _discussionReplyCommentsServices.CreateNewDiscussionReplyComment(discussionReplyComment);

                return new ICreateNewDiscussionReplyCommentFunction.Response(true, null);
            }

            return new ICreateNewDiscussionReplyCommentFunction.Response(false, "This discussion comment does not exist");
        }

        public async Task<IDeleteDiscussionFunction.Response> DeleteDiscussion(IDeleteDiscussionFunction.Request request)
        {
            var discussion = await _discussionsRepository.findDiscussionById(request.discussionId);

            if (discussion != null && discussion.IsDeleted.Equals(false) && discussion.AuthorId.Equals(request.userId))
            {
                discussion.IsDeleted = true;
                discussion.UpdateDate = DateTime.UtcNow;

                await _discussionsRepository.updateDiscussion(discussion);

                return new IDeleteDiscussionFunction.Response(true, null);
            }

            return new IDeleteDiscussionFunction.Response(false, "This discussion does not exist");
        }

        public async Task<IDeleteDiscussionCommentFunction.Response> DeleteDiscussionComment(IDeleteDiscussionCommentFunction.Request request)
        {
            var discussionComment = await _discussionCommentsServices.FindDiscussionCommentById(request.commentId);

            if (discussionComment != null && discussionComment.IsDeleted.Equals(false) && discussionComment.AuthorId.Equals(request.userId))
            {
                discussionComment.IsDeleted = true;
                discussionComment.UpdateDate = DateTime.UtcNow;

                await _discussionCommentsServices.UpdateDiscussionComment(discussionComment);

                return new IDeleteDiscussionCommentFunction.Response(true, null);
            }

            return new IDeleteDiscussionCommentFunction.Response(false, "This discussion comment does not exist");
        }

        public async Task<IDeleteDiscussionReplyCommentFunction.Response> DeleteDiscussionReplyComment(IDeleteDiscussionReplyCommentFunction.Request request)
        {
            var discussionReplyComment = await _discussionReplyCommentsServices.FindDiscussionReplyCommentById(request.replyCommentId);

            if(discussionReplyComment != null && discussionReplyComment.IsDeleted.Equals(false) && discussionReplyComment.AuthorId.Equals(request.userId))
            {
                discussionReplyComment.IsDeleted = true;
                discussionReplyComment.UpdateDate = DateTime.UtcNow;

                await _discussionReplyCommentsServices.UpdateDiscussionReplyComment(discussionReplyComment);

                return new IDeleteDiscussionReplyCommentFunction.Response(true, null);
            }

            return new IDeleteDiscussionReplyCommentFunction.Response(false, "This discussion reply comment does not exist");
        }

        public async Task<IDiscussionCommentActionFunction.Response> DiscussionCommentAction(IDiscussionCommentActionFunction.Request request)
        {
            var discussionCommentAction = await _discussionCommentActionsServices.FindDiscussionCommentActionByUserIdAndCommentId(request.discussionCommentAction.userId, request.discussionCommentAction.commentId);

            if(discussionCommentAction != null)
            {
                switch (request.discussionCommentAction.actionId)
                {
                    case 0:
                        {
                            if (discussionCommentAction.IsDisliked)
                            {
                                discussionCommentAction.IsDisliked = false;
                            }

                            if (discussionCommentAction.IsLiked)
                            {
                                discussionCommentAction.IsLiked = false;
                            }
                            else if (!discussionCommentAction.IsLiked)
                            {
                                discussionCommentAction.IsLiked = true;
                            }
                        } break;

                    case 1:
                        {
                            if (discussionCommentAction.IsLiked)
                            {
                                discussionCommentAction.IsLiked = false;
                            }

                            if (discussionCommentAction.IsDisliked)
                            {
                                discussionCommentAction.IsDisliked = false;
                            }
                            else if (!discussionCommentAction.IsDisliked)
                            {
                                discussionCommentAction.IsDisliked = true;
                            }
                        } break;
                }

                await _discussionCommentActionsServices.UpdateDiscussionCommentAction(discussionCommentAction);

                return new IDiscussionCommentActionFunction.Response(true, "Your action successful");
            }
            else
            {
                DiscussionCommentActions commentAction = new DiscussionCommentActions()
                {
                    DiscussionCommentId = request.discussionCommentAction.commentId,
                    UserId = request.discussionCommentAction.userId,
                    IsLiked = false,
                    IsDisliked = false,
                };

                switch (request.discussionCommentAction.actionId)
                {
                    case 0:
                        {
                            commentAction.IsLiked = true;
                        } break;

                    case 1:
                        {
                            commentAction.IsDisliked = true;
                        } break;
                }

                await _discussionCommentActionsServices.CreateNewDiscussionCommentAction(commentAction);

                return new IDiscussionCommentActionFunction.Response(true, "Your action successful");
            }
        }

        public async Task<IDiscussionReplyCommentActionFunction.Response> DiscussionReplyCommentAction(IDiscussionReplyCommentActionFunction.Request request)
        {
            var discussionReplyCommentAction = await _discussionReplyCommentActionsServices.FindDiscussionReplyCommentActionsByUserIdAndReplyCommentId(request.discussionReplyCommentAction.userId, request.discussionReplyCommentAction.commentId);

            if(discussionReplyCommentAction != null)
            {
                switch (request.discussionReplyCommentAction.actionId)
                {
                    case 0:
                        {
                            if (discussionReplyCommentAction.IsDisliked)
                            {
                                discussionReplyCommentAction.IsDisliked = false;
                            }

                            if (discussionReplyCommentAction.IsLiked)
                            {
                                discussionReplyCommentAction.IsLiked = false;
                            }
                            else if (!discussionReplyCommentAction.IsLiked)
                            {
                                discussionReplyCommentAction.IsLiked = true;
                            }
                        } break;

                    case 1:
                        {
                            if (discussionReplyCommentAction.IsLiked)
                            {
                                discussionReplyCommentAction.IsLiked = false;
                            }

                            if (discussionReplyCommentAction.IsDisliked)
                            {
                                discussionReplyCommentAction.IsDisliked = false;
                            }
                            else if (!discussionReplyCommentAction.IsDisliked)
                            {
                                discussionReplyCommentAction.IsDisliked = true;
                            }
                        } break;
                }

                await _discussionReplyCommentActionsServices.UpdateDiscussionReplyCommentAction(discussionReplyCommentAction);

                return new IDiscussionReplyCommentActionFunction.Response(true, "Your action successful");
            }
            else
            {
                DiscussionReplyCommentActions replyCommentAction = new DiscussionReplyCommentActions()
                {
                    DiscussionReplyCommentId = request.discussionReplyCommentAction.commentId,
                    UserId = request.discussionReplyCommentAction.userId,
                    IsLiked = false,
                    IsDisliked = false,
                };

                switch (request.discussionReplyCommentAction.actionId)
                {
                    case 0:
                        {
                            replyCommentAction.IsLiked = true;
                        } break;

                    case 1:
                        {
                            replyCommentAction.IsDisliked = true;
                        } break;
                }

                await _discussionReplyCommentActionsServices.CreateNewDiscussionReplyCommentAction(replyCommentAction);

                return new IDiscussionReplyCommentActionFunction.Response(true, "Your action successful");
            }
        }

        public async Task<IGetDiscussionsFunction.Response> GetDiscussions(IGetDiscussionsFunction.Request request)
        {
            var discussions = await _discussionsRepository.getAllDiscussions();

            discussions = discussions.Where(d => d.IsDeleted.Equals(false))
                .OrderByDescending(d => d.CreateDate).ToList();

            if (discussions != null && discussions.Count() > 0)
            {
                var users = await _usersServices.GetAllUsers();
                var comments = await _discussionCommentsServices.GetAllDiscussionComments();
                var replyComments = await _discussionReplyCommentsServices.GetAllDiscussionReplyComments();

                int totalPages = await _commonUtil.totalPages(request.pageSize, discussions.Count());

                discussions = discussions.Skip((request.pageNumber - 1) * request.pageSize).Take(request.pageSize).ToList();

                List<IGetDiscussionsFunction.Discussion> discussionsList = new List<IGetDiscussionsFunction.Discussion>();

                foreach (var discussion in discussions)
                {
                    var comment = comments
                        .Where(c => c.DiscussionId.Equals(discussion.Id))
                        .Where(c => c.IsDeleted.Equals(false))
                        .ToList();

                    int totalComments = comment.Count();

                    foreach (var item in comment)
                    {
                        var replyComment = replyComments
                            .Where(c => c.DiscussionCommentId.Equals(item.Id))
                            .Where(c => c.IsDeleted.Equals(false))
                            .ToList();

                        totalComments += replyComment.Count();
                    }

                    IGetDiscussionsFunction.Discussion data = new IGetDiscussionsFunction.Discussion()
                    {
                        discussionId = discussion.Id,
                        discussionName = discussion.Name,
                        discussionDescription = discussion.Description,
                        discussionImage = discussion.Image,
                        totalComments = totalComments,
                        authorId = discussion.AuthorId,
                        authorName = users.SingleOrDefault(u => u.Id.Equals(discussion.AuthorId)).UserName,
                        discussionDate = discussion.CreateDate.ToLocalTime(),
                    };

                    discussionsList.Add(data);
                }

                return new IGetDiscussionsFunction.Response(totalPages, discussionsList);
            }

            return new IGetDiscussionsFunction.Response(0, null);
        }

        public async Task<IGetDiscussionDetailsFunction.Response> GetDiscussionDetails(IGetDiscussionDetailsFunction.Request request)
        {
            var discussion = await _discussionsRepository.findDiscussionById(request.discussionId);

            if (discussion != null && discussion.IsDeleted.Equals(false))
            {
                var users = await _usersServices.GetAllUsers();
                var comments = await _discussionCommentsServices.FindDiscussionCommentByDiscussionId(discussion.Id);
                var replyComments = await _discussionReplyCommentsServices.GetAllDiscussionReplyComments();
                var commentActions = await _discussionCommentActionsServices.GetAllDiscussionCommentActions();
                var replyCommentActions = await _discussionReplyCommentActionsServices.GetAllDiscussionReplyCommentActions();

                comments = comments.Where(c => c.IsDeleted.Equals(false)).ToList();

                int totalComments = comments.Count();

                List<IGetDiscussionDetailsFunction.Comment> commentsList = new List<IGetDiscussionDetailsFunction.Comment>();

                if (comments != null && comments.Count() > 0)
                {
                    foreach (var comment in comments)
                    {
                        List<IGetDiscussionDetailsFunction.ReplyComment> replyCommentsList = new List<IGetDiscussionDetailsFunction.ReplyComment>();

                        var replyComment = replyComments
                            .Where(r => r.DiscussionCommentId.Equals(comment.Id))
                            .Where(r => r.IsDeleted.Equals(false))
                            .ToList();

                        if (replyComment != null && replyComment.Count() > 0)
                        {
                            totalComments += replyComment.Count();

                            foreach(var item in replyComment)
                            {
                                var replyCommentAction = replyCommentActions.Where(r => r.DiscussionReplyCommentId.Equals(item.Id)).ToList();

                                IGetDiscussionDetailsFunction.ReplyComment replyCommentData = new IGetDiscussionDetailsFunction.ReplyComment()
                                {
                                    commentId = item.Id,
                                    content = item.Content,
                                    authorId = item.AuthorId,
                                    authorName = users.SingleOrDefault(u => u.Id.Equals(item.AuthorId)).UserName,
                                    numberOfLike = replyCommentAction.Where(r => r.IsLiked.Equals(true)).Count(),
                                    isLiked = replyCommentAction.Where(c => c.UserId.Equals(request.userId)).Where(c => c.IsLiked.Equals(true)).Select(s => s.IsLiked).SingleOrDefault(),
                                    numberOfDislike = replyCommentAction.Where(r => r.IsDisliked.Equals(true)).Count(),
                                    isDisliked = replyCommentAction.Where(c => c.UserId.Equals(request.userId)).Where(c => c.IsDisliked.Equals(true)).Select(s => s.IsDisliked).SingleOrDefault(),
                                    commentDate = item.CreateDate.ToLocalTime(),
                                };

                                replyCommentsList.Add(replyCommentData);
                            }
                        }

                        var commentAction = commentActions.Where(c => c.DiscussionCommentId.Equals(comment.Id)).ToList();

                        IGetDiscussionDetailsFunction.Comment commentData = new IGetDiscussionDetailsFunction.Comment()
                        {
                            commentId = comment.Id,
                            content = comment.Content,
                            authorId = comment.AuthorId,
                            authorName = users.SingleOrDefault(u => u.Id.Equals(comment.AuthorId)).UserName,
                            numberOfLike = commentAction.Where(c => c.IsLiked.Equals(true)).Count(),
                            isLiked = commentAction.Where(c => c.UserId.Equals(request.userId)).Where(c => c.IsLiked.Equals(true)).Select(s => s.IsLiked).SingleOrDefault(),
                            numberOfDislike = commentAction.Where(c => c.IsDisliked.Equals(true)).Count(),
                            isDisliked = commentAction.Where(c => c.UserId.Equals(request.userId)).Where(c => c.IsDisliked.Equals(true)).Select(s => s.IsDisliked).SingleOrDefault(),
                            commentDate = comment.CreateDate.ToLocalTime(),
                            replyComments = replyCommentsList
                        };

                        commentsList.Add(commentData);
                    }
                }

                return new IGetDiscussionDetailsFunction.Response(discussion.Id, discussion.Name, discussion.Content, totalComments, discussion.AuthorId, users.SingleOrDefault(u => u.Id.Equals(discussion.AuthorId)).UserName, discussion.CreateDate.ToLocalTime(), commentsList);
            }

            return new IGetDiscussionDetailsFunction.Response();
        }
    }
}
