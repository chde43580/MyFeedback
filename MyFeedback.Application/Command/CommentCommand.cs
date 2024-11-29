﻿using MyFeedback.Application.Command.CommandDto.Comment;
using MyFeedback.Application.Repositories;
using MyFeedback.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Application.Command
{
    public class CommentCommand : ICommentCommand
    {
        private readonly ICommentRepo _commentRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CommentCommand(ICommentRepo commentRepo, IUnitOfWork unitOfWork)
        {
            _commentRepo = commentRepo;
            _unitOfWork = unitOfWork;
        }

        void ICommentCommand.CreateComment(CreateCommentDto createCommetDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);

                Comment newComment = Comment.Create(createCommetDto.CommentText, createCommetDto.CommentDate, new List<PastComment>(), createCommetDto.IdentityUserId);

                _commentRepo.AddComment(newComment);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw (ex);
            }

            
        }

        void ICommentCommand.UpdateComment(UpdateCommentDto updateCommentDto)
        {
            throw new NotImplementedException(); //TODO: Lav metode for update, hvor den laver comment til pastComment
        }
    }
}
