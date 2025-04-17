$.validator.addMethod('filesize', function (value, element, par) {
    return this.optional(element) || element.files[0].size <= par;
});
//$.validator.addMethod('filesize', function (value, element, param) {
//    return this.optional(element) || element.files[0].size <= param;
//});
