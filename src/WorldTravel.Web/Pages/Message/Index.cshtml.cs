using WorldTravel.Abstract;
using WorldTravel.Dtos.MessageContents.ViewModels;
using WorldTravel.Dtos.Messages.ViewModels;
using WorldTravel.Dtos.Users.ViewModels;
using WorldTravel.Models.Results.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Identity.Web.Pages.Identity;

namespace WorldTravel.Web.Pages.Message
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class IndexModel : WorldTravelPageModel
    {
        //[BindProperty]
        //public UserManageModel UserManageInputModel { get; set; }
        public AppUserViewModel UserViewModel { get; set; }
        public List<MessageViewModel> MessageViewModel { get; set; }


        private readonly IUserAppService _userAppService;
        private readonly IMessageAppService _messageAppService;

        public IndexModel(
            IUserAppService userAppService,
            IMessageAppService messageAppService
            )
        {
            _userAppService = userAppService;
            _messageAppService = messageAppService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                if (!CurrentUser.IsAuthenticated)
                    return Redirect("~/Error?httpStatusCode=401");

                UserViewModel = (await _userAppService.GetAppUserAsync(CurrentUser.Id.Value)).Data;
                MessageViewModel = (await _messageAppService.GetUserMessageListAsync()).Data;

                return Page();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Account > Message > OnGetAsync  has error!");
                Alerts.Danger(L["GeneralError"].Value);

                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ManageProfileModel input = new ManageProfileModel();
                    //input.Name = UserManageInputModel.Name;
                    //input.Surname = UserManageInputModel.Surname;
                    //input.Email = UserManageInputModel.Email;
                    //input.PhoneNumber = UserManageInputModel.PhoneNumber;
                    //input.BirthDate = UserManageInputModel.BirthDate;
                    //var result = await _userAppService.ManageProfileAsync(CurrentUser.Id.Value, input);
                    //if (result.Success)
                    return RedirectToAction("Manage", "Account");

                }

                Alerts.Danger(L["GeneralError"].Value);

                return Page();

            }
            //catch (AbpIdentityResultException ex)
            //{
            //    var identityError = ex.IdentityResult;
            //    if (!identityError.Succeeded && identityError.Errors.Any())
            //    {
            //        var totalErrorCount = identityError.Errors.Count();
            //        if (identityError.Errors.Any(x => x.Code == "DuplicateUserName"))
            //        {
            //            Alerts.Danger($"'{UserManageInputModel.UserName}' kullanıcı adına sahip bir kullanıcı zaten var.");
            //            totalErrorCount--;
            //        }
            //        if (identityError.Errors.Any(x => x.Code == "DuplicateEmail"))
            //        {
            //            Alerts.Danger($"'{UserManageInputModel.Email}' mailine sahip bir kullanıcı zaten var.");
            //            totalErrorCount--;
            //        }
            //        if (totalErrorCount > 0)
            //        {
            //            Alerts.Danger(L["GeneralIdentityError"].Value);
            //        }
            //    }

            //    return Page();
            //}
            catch (Exception ex)
            {
                Log.Error(ex, "Account > Message > OnPostAsync  has error!");
                Alerts.Danger(L["GeneralError"].Value);

                return Page();
            }
        }

        public async Task<JsonResult> OnPostUploadMessageContents(int messageId)
        {
            try
            {
                var result = await _messageAppService.GetUserMessageWithContentListAsync(messageId);
                if (result.Success)
                    return new JsonResult(new SuccessDataResult<List<MessageWithContentViewModel>>(result.Data));

                return new JsonResult(new ErrorResult(result.Message));

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Account > Message > OnPostUploadMessageContents  has error!");
                Alerts.Danger(L["GeneralError"].Value);

                return new JsonResult(new ErrorResult(L["GeneralError"].Value));
            }
        }

        public async Task<JsonResult> OnPostDeleteMessageContent(int messageContentId)
        {
            try
            {
                //var result = await _messageAppService.DeleteMessageContentAsync(messageContentId);
                //if (result.Success)
                //    return new JsonResult(new SuccessDataResult<List<MessageWithContentViewModel>>(result.Data));

                return new JsonResult(new ErrorResult(L["GeneralError"].Value));

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Account > Message > OnPostUploadMessageContents  has error!");
                Alerts.Danger(L["GeneralError"].Value);

                return new JsonResult(new ErrorResult(L["GeneralError"].Value));
            }
        }

        //public class UserManageModel
        //{
        //    [HiddenInput]
        //    public Guid Id { get; set; }
        //    [DisabledInput]
        //    public string UserName { get; set; }
        //    [Required]
        //    public string Name { get; set; }
        //    [Required]
        //    public string Surname { get; set; }
        //    [Required]
        //    [EmailAddress]
        //    public string Email { get; set; }
        //    [Required]
        //    [Phone]
        //    [StringLength(16, MinimumLength = 16, ErrorMessage = "Telefon alanı geçerli bir telefon numarası olmalıdır.")]
        //    public string PhoneNumber { get; set; }
        //    public DateTime CreationTime { get; set; }
        //    [DisabledInput]
        //    public GenderType Gender { get; set; }
        //    public DateTime? BirthDate { get; set; }
        //    public string ImageUrl { get; set; }

        //}
    }
}
