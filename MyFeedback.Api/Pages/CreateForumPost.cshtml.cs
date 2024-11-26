using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyFeedback.Application.Command;
using MyFeedback.Application.Command.CommandDto.ForumPost;
using MyFeedback.Application.Query.QueryDto;

namespace MyFeedback.Api.Pages
{
    public class CreateForumPostModel : PageModel
    {
        private readonly IForumPostCommand _forumPostCommand;

        public CreateForumPostModel(IForumPostCommand forumPostCommand)
        {
            this._forumPostCommand = forumPostCommand;
        }

        [BindProperty]
        public ForumPostDto ForumPostDto { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            else
            {
                CreateForumPostDto createForumPostDto = new CreateForumPostDto
                {
                    ProblemText = ForumPostDto.ProblemText,
                    SolutionText = ForumPostDto.SolutionText,
                };
                   

                _forumPostCommand.CreateForumPost(createForumPostDto);

                return Redirect(Request.Headers["Referer"].ToString());
            }
        }
    }
}
