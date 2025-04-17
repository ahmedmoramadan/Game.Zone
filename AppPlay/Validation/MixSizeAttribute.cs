using System.Security.AccessControl;

namespace APPPlay.Validation
{
    public class MixSizeAttribute : ValidationAttribute
    {
        private readonly int _maxsize;
        public MixSizeAttribute(int maxsize)
        {
            _maxsize = maxsize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if(file.Length > _maxsize)
                {
                    return new ValidationResult($"maximum allowed size is {_maxsize} bytes");
                }
            }
            return ValidationResult.Success;
        }
    }
}
