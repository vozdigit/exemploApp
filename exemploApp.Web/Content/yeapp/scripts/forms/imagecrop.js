!function (document,window,$){
    "use strict";
    $("#simpleCropper img").cropper({
        preview: "#simpleCropperPreview >.img-preview",
        responsive: !0
    })
    var $exampleFullCropper=$("#exampleFullCropper img")
            ,$inputDataX=$("#inputDataX")
            ,$inputDataY=$("#inputDataY")
            ,$inputDataHeight=$("#inputDataHeight")
            ,$inputDataWidth=$("#inputDataWidth")
            ,options={
                aspectRatio: 16/9,
                preview: "#exampleFullCropperPreview > .img-preview",
                responsive: !0,
                crop: function (){
                    var data=$(this).data("cropper").getCropBoxData();
                    $inputDataX.val(Math.round(data.left)),
                            $inputDataY.val(Math.round(data.top)),
                            $inputDataHeight.val(Math.round(data.height)),
                            $inputDataWidth.val(Math.round(data.width))
                }
            };
    $exampleFullCropper.cropper(options),
            $(document).on("click","[data-cropper-method]",function (){
        var result,data=$(this).data(),method=$(this).data("cropper-method");
        method&&(result=$exampleFullCropper.cropper(method,data.option)),
                "getCroppedCanvas"===method&&$("#getDataURLModal").modal().find(".modal-body").html(result)
    });
    var $inputImage=$("#inputImage");
    window.FileReader ? $inputImage.change(function (){
        var file,fileReader=new FileReader,files=this.files;
        files.length&&(file=files[0],
                /^image\/\w+$/.test(file.type) ? (fileReader.readAsDataURL(file),
                fileReader.onload=function (){
                    $exampleFullCropper.cropper("reset",!0).cropper("replace",this.result),
                            $inputImage.val("")
                }
        ) : showMessage("Please choose an image file."))
    }) : $inputImage.addClass("hide"),
            $("#setCropperData").click(function (){
        var data={
            left: parseInt($inputDataX.val()),
            top: parseInt($inputDataY.val()),
            width: parseInt($inputDataWidth.val()),
            height: parseInt($inputDataHeight.val())
        };
        $exampleFullCropper.cropper("setCropBoxData",data)
    })
}(document,window,jQuery);
