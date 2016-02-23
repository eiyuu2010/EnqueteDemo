function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}


function MM_openBrWindow(theURL,winName,features) { //v2.0
	window.open(theURL,winName,features);
}

function newXMLHttpRequest() {
	var xmlreq = false;
	if (window.XMLHttpRequest) {
		// Create XMLHttpRequest object in non-Microsoft browsers
		xmlreq = new XMLHttpRequest();
	} else if (window.ActiveXObject) {
		// Create XMLHttpRequest via MS ActiveX
		try {
			// Try to create XMLHttpRequest in later versions
			// of Internet Explorer
			xmlreq = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e1) {
			// Failed to create required ActiveXObject
			try {
				// Try version supported by older versions
				// of Internet Explorer
				xmlreq = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e2) {
				// Unable to create an XMLHttpRequest with ActiveX
			}
		}
	}
	return xmlreq;
}

function wClose() {
	try {
		window.close();
	} finally {
		return	false;
	}
}

// 内容をコピーする。
function copyText(id){
    str = document.getElementById(id).innerHTML;

    str = str.replace(/&lt;/g, "<");
    str = str.replace(/&gt;/g, ">");

    isCopy = clipboardData.setData("text", str);
    if (isCopy) {
    	alert("リンクをコピーしました。");
    } else {
    	alert("クリップボードへアクセスが許可されてないためコピーできませんでした。");
    }
}

// 文言を指定して内容をコピーする。
// 内容をコピーする。
function copyTextMessage(id, Message){
    str = document.getElementById(id).innerHTML;

    str = str.replace(/&lt;/g, "<");
    str = str.replace(/&gt;/g, ">");

    isCopy = clipboardData.setData("text", str);
    if (isCopy) {
    	alert(Message);
    } else {
    	alert("クリップボードへアクセスが許可されてないためコピーできませんでした。");
    }
}

// 表示枠より大きい画像は縮小表示する。小さい画像はそのまま。
function resizeLogo(mg) {
	var ratio = 36.0 / mg.height;
	if (mg.width * ratio > 360) ratio = 360.0 / mg.width;
	if (ratio > 1.0) ratio = 1.0;
	var newWidth = mg.width * ratio;
	var newHeight = mg.height * ratio;

    mg.width = newWidth;
    mg.height = newHeight;

    // 画像の活性化
    mg.style.visibility = "visible";
}

//表示枠より大きい画像は縮小表示する。小さい画像はそのまま。
function resizeResourceThumbnail(mg) {
	var ratio = 45.0 / mg.height;
	if (mg.width * ratio > 36) ratio = 36.0 / mg.width;
	if (ratio > 1.0) ratio = 1.0;
	var newWidth = mg.width * ratio;
	var newHeight = mg.height * ratio;

    mg.width = newWidth;
    mg.height = newHeight;

    // 画像の活性化
    mg.style.visibility = "visible";
    mg.style.display = "block";
}
function resizeResourceThumbnailLarge(mg) {
	var ratio = 90.0 / mg.height;
	if (mg.width * ratio > 72) ratio = 72.0 / mg.width;
	if (ratio > 1.0) ratio = 1.0;
	var newWidth = mg.width * ratio;
	var newHeight = mg.height * ratio;

    mg.width = newWidth;
    mg.height = newHeight;

    // 画像の活性化
    mg.style.visibility = "visible";
}

function resizeIcon(mg) {
	var ratio = 72.0 / mg.height;
	if (mg.width * ratio > 72) ratio = 72.0 / mg.width;
	if (ratio > 1.0) ratio = 1.0;
	var newWidth = mg.width * ratio;
	var newHeight = mg.height * ratio;

    mg.width = newWidth;
    mg.height = newHeight;

    // 画像の活性化
    mg.style.visibility = "visible";
}
function resizeThumbnail(obj) {
	var ratio = 0.0;
	var newWidth = 0.0;
	var newHeight = 0.0;
	var modifiedFlg = false;

	// 基準高さより大きい場合
	if (obj.height > 92) {
		ratio = obj.height / 92;
		newWidth = obj.width / ratio;
		if (newWidth <= 130) {
			obj.width = newWidth;
			obj.height = 92;
			modifiedFlg = true;
		}
	} else {
		ratio = 92 / obj.height;
		newWidth = obj.width * ratio;
		if (newWidth <= 130) {
			obj.width = newWidth;
			obj.height = 92;
			modifiedFlg = true;
		}
	}

	// まだイメージの幅・縦を修正しなかった場合
	if (!modifiedFlg) {
		obj.width = 130;
		obj.height = 92;
	}

	// 画像の活性化
	obj.style.visibility = "visible";
}

function resizeSmallThumbnail(obj) {
	var ratio = 0.0;
	var newWidth = 0.0;
	var newHeight = 0.0;
	var modifiedFlg = false;

	// 基準高さより大きい場合
	if (obj.height > 70) {
		ratio = obj.height / 70;
		newWidth = obj.width / ratio;
		if (newWidth <= 100) {
			obj.width = newWidth;
			obj.height = 70;
			modifiedFlg = true;
		}
	} else {
		ratio = 70 / obj.height;
		newWidth = obj.width * ratio;
		if (newWidth <= 100) {
			obj.width = newWidth;
			obj.height = 70;
			modifiedFlg = true;
		}
	}

	// まだイメージの幅・縦を修正しなかった場合
	if (!modifiedFlg) {
		obj.width = 100;
		obj.height = 70;
	}

	// 画像の活性化
	obj.style.visibility = "visible";
}

function resizeContentIcon(obj) {
	var ratio = 0.0;
	var newWidth = 0.0;
	var newHeight = 0.0;
	var modifiedFlg = false;

	// 基準高さより大きい場合
	if (obj.height > 72) {
		ratio = obj.height / 72;
		newWidth = obj.width / ratio;
		if (newWidth <= 72) {
			obj.width = newWidth;
			obj.height = 72;
			modifiedFlg = true;
		}
	} else {
		ratio = 72 / obj.height;
		newWidth = obj.width * ratio;
		if (newWidth <= 72) {
			obj.width = newWidth;
			obj.height = 72;
			modifiedFlg = true;
		}
	}

	// まだイメージの幅・縦を修正しなかった場合
	if (!modifiedFlg) {
		obj.width = 72;
		obj.height = 72;
	}

	// 画像の活性化
	obj.style.visibility = "visible";
}

function trim(str) {
	return str.replace(/(^\s+)|(\s+$)/g, "");
}

//body内の実際に表示される部分（スクロールされる部分）の高さに合わせてブラウザーの大きさを調整します。
//モニターの解像度を超えると、それ以上は調整されない。
function autoVResizeWindow(){
	newHeight = document.body.scrollHeight + 50;

	if(newHeight >= screen.availHeight - 50){
		window.dialogHeight = screen.availHeight - 50 + 'px';
	}else{
		window.dialogHeight = newHeight + 'px';
	}
}
//メールアドレスチェック
function mailAddressCheck(address) {
	return address.match(/^[\w!#$%&'*+/=?^_@{}\\|~-]+(\.[\w!#$%&'*+/=?^_{}\\|~-]+)*@([\w][\w-]*\.)+[\w][\w-]*$/);
}
//メールアドレスチェック携帯対応版
//連続ドットや@前ドットを許可
function mailAddressCheck4MobilePhone(address) {
	return address.match(/^[\w!#$%&'*+/=?^_@{}\\|~-]+([\w!#$%&'*+/=?^_{}\\|~\.-]+)*@([\w][\w-]*\.)+[\w][\w-]*$/);
}

// 簡易詳細切替
function searchModeChange(searchMode, resetFlg) {

	// 詳細検索に変更
	if (searchMode == 1) {
		$(".formsearchbox_simple").hide();
		$(".formsearchbox_detail").show();
		$("#searchMode").val("1");
	// 簡易検索に変更
	} else {
		$(".formsearchbox_simple").show();
		$(".formsearchbox_detail").hide();
		$("#searchMode").val("0");
	}

	// 値の初期化
	if (resetFlg && typeof clearForm == "function") {
		clearForm();
	}
}

jQuery.fn.center = function () {
	var top = ( $(window).height() - this.height() ) / 2 - 50;
	var left = ( $(window).width() - this.width() ) / 2;

	this.css({
	  "top": top + "px",
	  "left": left + "px"
	});

	return this;
}

$(window).resize(function(){
	// 処理中ダイアログ表示対応
	if (!$("#showPlayType").is(":hidden")) {
		$("#blockSreeen").fadeIn("slow");
		$("#showPlayType").center().fadeIn("slow");
	}
});

var INIT_OUTER_HEIGHT = 0;
var INIT_INNER_HEIGHT = 0;

//一覧に合わせてウィンドウの高さ調整
function resizeWindow() {
	// wrapperpopが存在するかどうかチェックする
	if($("#wrapperpop").length == 0) {
		return;
	}

	// 最初に開いた時にウィンドウの高さ・横幅をセットする
	if (INIT_OUTER_HEIGHT == 0) {
		INIT_OUTER_HEIGHT = window.outerHeight;
		INIT_INNER_HEIGHT = window.innerHeight;
	}

	// wrapper（ウィンドウ）の外側高さ
	var outerHeightOfWrapper = $("#wrapperpop").height();
	// wrapperの内側高さ
	var innerHeightOfWrapper = 130;
	$("#wrapperpop").children().each(function() {
		innerHeightOfWrapper += $(this).height();
	});

	if (innerHeightOfWrapper > INIT_INNER_HEIGHT) {
		outerHeightOfWrapper = INIT_OUTER_HEIGHT;
	} else {
		// innerHeightの差分から、outerHeightを算出する。
		outerHeightOfWrapper = INIT_OUTER_HEIGHT - (INIT_INNER_HEIGHT - innerHeightOfWrapper);
	}

	// ウィンドウサイズを変更する。
	window.resizeTo(window.outerWidth, outerHeightOfWrapper);
}

String.prototype.startsWith = function(prefix, toffset) {
	var i = 0;
	if(toffset && (typeof toffset === 'number')) {
	    i = toffset;
	}
	return this.slice(i).indexOf(prefix) === 0;
};

String.prototype.endsWith = function(suffix) {
	var sub = this.length - suffix.length;
	return (sub >= 0) && (this.lastIndexOf(suffix) === sub);
};
	