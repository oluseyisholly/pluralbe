using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace EcommerceWebApi.Common.Attributes
{
    public class FromUserClaimModelBinder(string claimType) : IModelBinder
    {
        private readonly string _claimType = claimType;

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var user = bindingContext.HttpContext.User;
            var claim = user.FindFirst(_claimType);

            if (claim != null)
            {
                bindingContext.Result = ModelBindingResult.Success(claim.Value);
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }

    public class FromUserClaimBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            // Only applies to parameters (not properties or types)
            if (
                context.Metadata is DefaultModelMetadata metadata
                && metadata.MetadataKind == ModelMetadataKind.Parameter
            )
            {
                var attr = metadata
                    .Attributes.ParameterAttributes?.OfType<FromUserClaimAttribute>()
                    .FirstOrDefault();

                if (attr != null)
                {
                    return new FromUserClaimModelBinder(attr.ClaimType);
                }
            }

            return null;
        }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class FromUserClaimAttribute(string claimType) : Attribute
    {
        public string ClaimType { get; } = claimType;
    }
}
