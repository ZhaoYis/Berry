/**
 * 
 */

var isIE = !!window.ActiveXObject;
var isIE6 = isIE && !window.XMLHttpRequest;
if (isIE6) {
    alert("浏览器版本过低，系统暂不支持！");
    //window.location.href = "";
}

//响应回车键
document.onkeydown = function (e) {
    if (!e) e = window.event;
    if ((e.keyCode || e.which) == 13) {
        var btn = document.getElementById("btnlogin");
        btn.click();
    }
}

//初始化
$(function () {
    $(".wrap").css("margin-top", ($(window).height() - $(".wrap").height()) / 2 - 35);
    $(window).resize(function (e) {
        $(".wrap").css("margin-top", ($(window).height() - $(".wrap").height()) / 2 - 35);
        e.stopPropagation();
    });

    //错误提示
    var error = top.$.cookie('__login_error__');
    if (error != null) {
        switch (error) {
            case "1":
                formMessage('登录已超时,请重新登录');
                break;
            case "2":
                formMessage('您的帐号已在其它地方登录,请重新登录');
                break;
            case "-1":
                formMessage('未知错误,请重新登录');
                break;
        }
        top.$.cookie('__login_error__', '', { path: "/", expires: -1 });
    }

    //是否自动登录
    if (top.$.cookie('__autologin') == 1) {
        $("#autologin").attr("checked", 'true');
        $("#username").val(top.$.cookie('__username'));
        $("#password").val(top.$.cookie('__password'));
        CheckLogin(1);
    }

    //设置下次自动登录
    $("#autologin").click(function () {
        if (!$(this).attr('checked')) {
            $(this).attr("checked", 'true');
            top.$.cookie('__autologin', 1, { path: "/", expires: 7 });
        } else {
            $(this).removeAttr("checked");
            top.$.cookie('__autologin', '', { path: "/", expires: -1 });
            top.$.cookie('__username', '', { path: "/", expires: -1 });
            top.$.cookie('__password', '', { path: "/", expires: -1 });
        }
    });

    //登录按钮事件
    $("#btnlogin").click(function () {
        var $username = $("#username");
        var $password = $("#password");
        var $verifycode = $("#code");
        if ($username.val() == "") {
            $username.focus();
            formMessage('请输入账户或手机号或邮箱。');
            return false;
        } else if ($password.val() == "") {
            $password.focus();
            formMessage('请输入密码。');
            return false;
        } else if ($verifycode.val() == "") {
            $verifycode.focus();
            formMessage('请输入验证码。');
            return false;
        } else {
            CheckLogin(0);
        }
    });

    //点击切换验证码
    $("#login_code").click(function () {
        $("#code").val('');
        $("#login_code").attr("src", "/Login/VerifyCode?time=" + new Date().getTime());
    });
});

//登录校验
function CheckLogin(autologin) {
    $("#btnlogin").addClass('active').attr('disabled', 'disabled');
    $("#btnlogin").find('span').hide();

    var username = $.trim($("#username").val());
    var password = $.trim($("#password").val());
    var code = $.trim($("#code").val());
    //获取cookie保存的密码
    var passwordCookie = top.$.cookie('__password');
    if (passwordCookie == "" || passwordCookie == null) {
        password = $.md5(password);
    }
    $.AjaxRequest({
        url: "/Login/CheckLogin",
        param: {
            username: username,
            password: password,
            verifycode: code,
            autologin: autologin
        },
        success: function (req) {
            if (req.Status == 2000) {
                //检查是否自动登录，如果是则更新cookie
                if (top.$.cookie('__autologin') == 1) {
                    top.$.cookie('__username', username, { path: "/", expires: 7 });
                    top.$.cookie('__password', password, { path: "/", expires: 7 });
                }
                //跳转
                window.location.href = req.BackUrl;
            } else {
                dialogAlert(req.Message, 0);
                //清理工作
                $("#btnlogin").removeClass('active').removeAttr('disabled');
                $("#btnlogin").find('span').show();
                $("#login_code").trigger("click");
            }
        }
    });
}

//提示信息
function formMessage(msg, type) {
    $('.login_tips').parents('dt').remove();
    var _class = "login_tips";
    if (type == 1) {
        _class = "login_tips-succeed";
    }
    $('.form').prepend('<dt><div class="' + _class + '"><i class="fa fa-question-circle"></i>' + msg + '</div></dt>');
}