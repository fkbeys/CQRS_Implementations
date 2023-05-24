using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sales.Application.App_Wrappers.ResponseWrappers;

namespace Sales.WebApi.MiddlewaresAndHelpers
{

    public class ModelStateErrorConverter : ActionFilterAttribute
    {
        /// <summary>
        /// if the request model is not valid, we need to return back a standart response. 
        /// So, i collect the error messages in order to inform the user about the what s the problem with his request data...
        /// this action filter will do this for us. 
        /// if the filter is valid, it will work as normal.
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
                string errors = "";
                try
                {
                    foreach (var item in context.ModelState.Values)
                    {
                        errors += item.Errors[0].ErrorMessage.ToString() + " / ";
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    context.Result = new NotFoundObjectResult(new ServiceResponse<bool>(false)
                    {
                        isSuccess = false,
                        message = "Model is not valid! " + errors
                    });
                }
            }
            else
            {
                base.OnResultExecuting(context);
            }

        }

    }
}
