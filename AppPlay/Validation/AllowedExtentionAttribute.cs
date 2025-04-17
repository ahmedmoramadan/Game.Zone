namespace APPPlay.Validation
{
    public class AllowedExtentionAttribute : ValidationAttribute
    {
        private readonly string _allowedExtention;
        public AllowedExtentionAttribute(string allowedExtention)
        {
            _allowedExtention = allowedExtention;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile; 
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var allowedExtention = _allowedExtention.Split(',').Contains(extention , StringComparer.OrdinalIgnoreCase);
                if (!allowedExtention)
                {
                    return new ValidationResult($"only {_allowedExtention} are allowed ");
                }

            }
            return ValidationResult.Success;
        }
    }
    #region
    //private readonly string _allowExtention;
    //public AllowedExtentionAttribute(string allowExtention)
    //{
    //    _allowExtention = allowExtention;
    //}
    //protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    //{
    //    var file = value as IFormFile;
    //    if (file != null)
    //    {
    //        var Extention = Path.GetExtension(file.Name);
    //        var isallowed = _allowExtention.Split(',').Contains(Extention, StringComparer.OrdinalIgnoreCase);
    //        if (!isallowed)
    //        {
    //            return new ValidationResult($"only {_allowExtention} are allowed");
    //        }
    //    }
    //    return ValidationResult.Success;
    //}
    #endregion
}

