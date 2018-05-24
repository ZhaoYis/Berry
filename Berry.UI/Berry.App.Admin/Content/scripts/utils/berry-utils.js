/**
 * 保存表单
 * @param {} options 
 * @returns {} 
 */
$.SaveForm = function (options) {
    var defaults = {
        url: "",
        param: [],
        type: "post",
        dataType: "json",
        loading: "正在处理数据...",
        success: null,
        close: true
    };
    var options = $.extend(defaults, options);
    Loading(true, options.loading);
    if ($('[name=__RequestVerificationToken]').length > 0) {
        options.param["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
    }
    window.setTimeout(function () {
        $.ajax({
            url: options.url,
            data: options.param,
            type: options.type,
            dataType: options.dataType,
            success: function (data) {
                if (data.type == "3") {
                    dialogAlert(data.message, -1);
                } else {
                    Loading(false);
                    dialogMsg(data.message, 1);
                    options.success(data);
                    if (options.close == true) {
                        dialogClose();
                    }
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                Loading(false);
                dialogMsg(errorThrown, -1);
            },
            beforeSend: function () {
                Loading(true, options.loading);
            },
            complete: function () {
                Loading(false);
            }
        });
    }, 500);
}

/**
 * 填充表单数据
 * @param {} options 
 * @returns {} 
 */
$.SetForm = function (options) {
    var defaults = {
        url: "",
        param: [],
        type: "get",
        dataType: "json",
        success: null,
        async: false
    };
    var options = $.extend(defaults, options);
    $.ajax({
        url: options.url,
        data: options.param,
        type: options.type,
        dataType: options.dataType,
        async: options.async,
        success: function (data) {
            if (data != null && data.type == "3") {
                dialogAlert(data.message, -1);
            } else {
                options.success(data);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            dialogMsg(errorThrown, -1);
        }, beforeSend: function () {
            Loading(true);
        },
        complete: function () {
            Loading(false);
        }
    });
}

/**
 * 移除表单数据
 * @param {} options 
 * @returns {} 
 */
$.RemoveForm = function (options) {
    var defaults = {
        msg: "注：您确定要删除吗？该操作将无法恢复",
        loading: "正在删除数据...",
        url: "",
        param: [],
        type: "post",
        dataType: "json",
        success: null
    };
    var options = $.extend(defaults, options);
    dialogConfirm(options.msg, function (r) {
        if (r) {
            Loading(true, options.loading);
            window.setTimeout(function () {
                var postdata = options.param;
                if ($('[name=__RequestVerificationToken]').length > 0) {
                    postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
                }
                $.ajax({
                    url: options.url,
                    data: postdata,
                    type: options.type,
                    dataType: options.dataType,
                    success: function (data) {
                        if (data.type == "3") {
                            dialogAlert(data.message, -1);
                        } else {
                            dialogMsg(data.message, 1);
                            options.success(data);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        Loading(false);
                        dialogMsg(errorThrown, -1);
                    },
                    beforeSend: function () {
                        Loading(true, options.loading);
                    },
                    complete: function () {
                        Loading(false);
                    }
                });
            }, 500);
        }
    });
}

/**
 * 弹出提示框并通过Ajax提交数据
 * @param {} options 
 * @returns {} 
 */
$.ConfirmAjax = function (options) {
    var defaults = {
        msg: "提示信息",
        loading: "正在处理数据...",
        url: "",
        param: [],
        type: "post",
        dataType: "json",
        success: null
    };
    var options = $.extend(defaults, options);
    dialogConfirm(options.msg, function (r) {
        if (r) {
            Loading(true, options.loading);
            window.setTimeout(function () {
                var postdata = options.param;
                if ($('[name=__RequestVerificationToken]').length > 0) {
                    postdata["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
                }
                $.ajax({
                    url: options.url,
                    data: postdata,
                    type: options.type,
                    dataType: options.dataType,
                    success: function (data) {
                        Loading(false);
                        if (data.type == "3") {
                            dialogAlert(data.message, -1);
                        } else {
                            dialogMsg(data.message, 1);
                            options.success(data);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        Loading(false);
                        dialogMsg(errorThrown, -1);
                    },
                    beforeSend: function () {
                        Loading(true, options.loading);
                    },
                    complete: function () {
                        Loading(false);
                    }
                });
            }, 200);
        }
    });
}

/**
 * 检测是否存在相同指定值
 * @param {} controlId 
 * @param {} url 
 * @param {} param 
 * @returns {} 
 */
$.ExistField = function (controlId, url, param) {
    var $control = $("#" + controlId);
    if (!$control.val()) {
        return false;
    }
    var data = {
        keyValue: request('keyValue')
    };
    data[controlId] = $control.val();
    var options = $.extend(data, param);
    $.ajax({
        url: url,
        data: options,
        type: "get",
        dataType: "text",
        async: false,
        success: function (data) {
            if (data.toLocaleLowerCase() == 'false') {
                ValidationMessage($control, '已存在,请重新输入');
                $control.attr('fieldexist', 'yes');
            } else {
                $control.attr('fieldexist', 'no');
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            dialogMsg(errorThrown, -1);
        }
    });
}

/**
 * Html转义
 * @param {} html 
 * @returns {} var tagText = "<p><b>123&456</b></p>";console.log(HTMLEncode(tagText));//&lt;p&gt;&lt;b&gt;123&amp;456&lt;/b&gt;&lt;/p&gt; 
 */
$.HTMLEncode = function (html) {
    var temp = document.createElement("div");
    (temp.textContent != null) ? (temp.textContent = html) : (temp.innerText = html);
    var output = temp.innerHTML;
    temp = null;
    return output;
}

/**
 * Html反转义
 * @param {} text 
 * @returns {} var tagText = "<p><b>123&456</b></p>";
    var encodeText = HTMLEncode(tagText);
    console.log(encodeText);//&lt;p&gt;&lt;b&gt;123&amp;456&lt;/b&gt;&lt;/p&gt;
    console.log(HTMLDecode(encodeText)); //<p><b>123&456</b></p> 
 */
$.HTMLDecode = function (text) {
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}

/**
 * 去掉所有的html标记
 * @param {} str 
 * @returns {} 
 */
$.RemoveHTMLTag = function (str) {
    str = $.HTMLDecode(str);
    //去除HTML tag
    str = str.replace(/<\/?[^>]*>/g, '');
    //去除行尾空白
    str = str.replace(/[ | ]*\n/g, '\n');
    //去除多余空行
    str = str.replace(/\n[\s| | ]*\r/g, '\n');
    //去掉&nbsp;
    str = str.replace(/&nbsp;/ig, '');
    return str;
}

/**
 * 截取指定长度字符串
 * @param {} str 
 * @param {} start 
 * @param {} len 
 * @returns {} 
 */
$.Substr = function (str, start, len) {
    return str.substr(start, len);
}

/**
 * Ajax请求
 * @param {} options 
 * @returns {} 
 */
$.AjaxRequest = function (options) {
    var defaults = {
        msg: "数据加载中...",
        url: "",
        param: {},
        type: "post",
        dataType: "json",
        async: true,
        success: null
    };
    var options = $.extend(defaults, options);
    var postdata = options.param;

    Loading(true, options.msg);
    $.ajax({
        url: options.url,
        data: postdata,
        type: options.type,
        dataType: options.dataType,
        async: options.async,
        success: function (data) {
            Loading(false);
            options.success(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            Loading(false);
            dialogMsg(errorThrown, -1);
        },
        beforeSend: function () {
            Loading(false);
        },
        complete: function () {
            Loading(false);
        }
    });
};

/**
 * 接收地址栏参数
 * @param {} key 
 * @returns {} 
 */
$.GetQuery = function (key) {
    var search = location.search.slice(1); //得到get方式提交的查询字符串
    var arr = search.split("&");
    for (var i = 0; i < arr.length; i++) {
        var ar = arr[i].split("=");
        if (ar[0] == key) {
            if (unescape(ar[1]) == 'undefined') {
                return "";
            } else {
                return unescape(ar[1]);
            }
        }
    }
    return "";
}

/**
 * 数组排序
 * @param source 待排序数组
 * @param orders 排序字段数组
 * @param type  升序-asc 倒序-desc
 * 调用：this.orderBy(arr, ['OpenTime'], 'desc')
 */
$.orderBy = function (source, orders, type) {

    if (source instanceof Array && orders instanceof Array && orders.length > 0) {

        var ordersc = orders.concat([]);
        var sorttype = type || 'asc';
        var results = [];
        var totalSum = {};

        function grouporder(source, orders, totalSum) {

            source.sort(function (a, b) {
                var convertA = a[orders[0]];
                var convertB = b[orders[0]];
                if (typeof convertA == 'string' && typeof convertB == 'string') {
                    if (sorttype.toUpperCase() == 'ASC') {
                        return convertA.localeCompare(convertB);
                    } else {
                        return convertB.localeCompare(convertA);
                    }
                } else {
                    if (sorttype.toUpperCase() == 'ASC') {
                        return convertA - convertB;
                    } else {
                        return convertB - convertA;
                    }
                }
            });

            var groupmap = new Map();
            source.forEach((item) => {
                if (groupmap.has(item[orders[0]])) {
                    groupmap.get(item[orders[0]]).push(item);
                } else {
                    groupmap.set(item[orders[0]], []);
                    groupmap.get(item[orders[0]]).push(item);
                }
            });

            orders.shift();

            for (let [key, val] of groupmap) {
                totalSum[key] = {};
                totalSum[key].name = key;
                totalSum[key].value = val.length;
                if (orders.length == 0) {
                    results = results.concat(val);
                } else {
                    totalSum[key].children = {};
                    var orderscopy = orders.concat([]);
                    grouporder(val, orderscopy, totalSum[key].children);
                }
            }
        }

        grouporder(source, ordersc, totalSum);

        return {
            results: results,
            totalSum: totalSum
        };
    } else {
        return source;
    }
}

/**
 * 判断checkbox是否选中
 * @param {} obj 
 * @returns {} 
 */
$.IsChecked = function (obj) {
    var type = $("#" + obj).attr('type');
    if (type === "checkbox") {

        return $("#" + obj).is(":checked");
    }
}
