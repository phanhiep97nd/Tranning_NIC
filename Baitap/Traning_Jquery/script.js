$(document).ready(function () {
    $.fn.setDefault();
    // $("#NameText_1").focus(function () {
    //     $("#AuthorInput").show();
    //     console.log("a");
    // });
    // $("#NameInput").mouseenter(function () {
    //     $("#AuthorInput").show();
    //     console.log("a")
    // });
    $(document).on("mouseover", "#AuthorText", function () {
        $("#AuthorInput").show();
        var author = $("#AuthorText").text();
        $("#AuthorInput").val(author);
        $("#AuthorText").hide();
    });

    $("#AuthorInput").mouseleave(function () {
        $("#AuthorText").text($("#AuthorInput").val());
        $("#AuthorInput").hide();
        $("#AuthorText").show();
    });
    //   $("#AuthorInput").focusout(function () {
    //     $("#AuthorText").text($("#AuthorInput").val());
    //     $("#AuthorInput").hide();
    //     $("#AuthorText").show();
    //   });
    $(document).on("mouseover", "#DateText", function () {
        $("#DateInput").show();
        var author = $("#DateText").text();
        $("#DateInput").val(author);
        $("#DateText").hide();
    });

    $("#DateInput").mouseleave(function () {
        $("#DateText").text($("#DateInput").val());
        $("#DateInput").hide();
        $("#DateText").show();
    });
    //   $("#DateInput").focusout(function () {
    //     $("#DateText").text($("#DateInput").val());
    //     $("#DateInput").hide();
    //     $("#DateText").show();
    //   });
    $("#Edit_1").click(function (e) {
        $("#NameText_1").hide();
        $("#NameInput_1").val($("#NameText_1").text());
        $(
            "#NameInput_1,#NewSkill_1,#AddSkill_1,#NoteInput_1,#Submit_1,#Cancel_1"
        ).show();
        $("#SexM_1,#SexF_1,#DevSelect_1,#PosSelect_1,#Exp_1").prop(
            "disabled",
            false
        );
        $("#Edit_1, #Delete_1").hide();
        $("#Skills_1 span").show();
    });
    $("#Cancel_1").click(function (e) {
        $("#SexF_1").prop("checked", true);
        $("option:selected", "#DevSelect_1").remove();
        $("option:selected", "#PosSelect_1").remove();
        $("#Exp_1").val("3");
        $("#Skills_1").html(
            "<li>C# <span>X</span></li> <li>SQL_SERVER <span>X</span></li>"
        );
        $.fn.setDefault();
    });
    $("#AddSkill_1").click(function (e) {
        if ($("#NewSkill_1").val() != "") {
            var skill = "<li>" + $("#NewSkill_1").val() + " <span>X</span></li>";
            $("#Skills_1").append(skill);
            $("#NewSkill_1").val("");
            $.fn.deleteSkill();
        }
    });
    $("#Submit_1").click(function (e) {
        $.fn.submit();
    });

    $("#Insert").click(function (e) {
        var rowDetail = $(".rowDetail").clone();
        $(".rowDetail").after(rowDetail);
    });
});
$.fn.setDefault = function () {
    $("#NameText_1").show();
    $("#AuthorInput,#DateInput,#NameInput_1").hide();
    $("#SexM_1,#SexF_1,#DevSelect_1,#PosSelect_1,#Exp_1").prop("disabled", true);
    $("#NewSkill_1,#AddSkill_1,#NoteInput_1,#Submit_1,#Cancel_1").hide();
    $("#Edit_1, #Delete_1").show();
    $("#Skills_1 span").hide();
};

$.fn.deleteSkill = function () {
    $("#Skills_1 span").click(function (e) {
        $(this).parent().hide();
    });
};
$.fn.submit = function () {
    $("#NameText_1").text($("#NameInput_1").val());
    $("#NoteText_1").text($("#NoteInput_1").val());
    $.fn.setDefault();
    console.log("submit");
};
