// Ajax.NET Professional - The free AJAX implementation for the Microsoft.NET Framework
// Copyright (C) 2005 Michael Schwarz, info@schwarz-interactive.de

if(!window.addNamespace)
{
	window.addNamespace = function(ns)
	{
		var nsParts = ns.split(".");
		var root = window;

		for(var i=0; i<nsParts.length; i++)
		{
			if(typeof root[nsParts[i]] == "undefined")
				root[nsParts[i]] = new Object();

			root = root[nsParts[i]];
		}
	}
}

if(!window.XMLHttpRequest)
{
	window.XMLHttpRequest = function()
	{
		var xmlHttp;
		
		try { xmlHttp = new ActiveXObject("Msxml2.XMLHTTP.4.0"); return xmlHttp; }catch(ex){}
		try { xmlHttp = new ActiveXObject("MSXML2.XMLHTTP"); return xmlHttp; }catch(ex){}
		try { xmlHttp = new ActiveXObject("Microsoft.XMLHTTP"); return xmlHttp; }catch(ex){}

		return null;
	}
}

// JavaScript Object Notation

Object.prototype.toJSON = function()
{
	var v=[];
	for(attr in this)
	{
		if(typeof this[attr] != "function")
			v.push('"' + attr + '": ' + (this[attr] != null ? this[attr].toJSON() : 'null'));
	}

	if(v.length>0)
		return "{" + v.join(", ") + "}";
	else
		return "{}";
}

String.prototype.toJSON = function()
{
	var s = this; // .encodeURI();
	s = '"' + s.replace(/(["\\])/g, '\\$1') + '"';
	s = s.replace(/\n/g,"\\n");
	s = s.replace(/\r/g,"\\r");
	
	return s;
}

Number.prototype.toJSON = function()
{
	return this.toString();
}

Boolean.prototype.toJSON = function()
{
	return this.toString();
}

Date.prototype.toJSON = function()
{
	var o = new Object();
	o.__type = "System.DateTime";
	o.Year = this.getUTCFullYear();
	o.Month = this.getUTCMonth() +1;
	o.Day = this.getUTCDate();
	o.Hour = this.getUTCHours();
	o.Minute = this.getUTCMinutes();
	o.Second = this.getUTCSeconds();
	o.Millisecond = this.getUTCMilliseconds();
	o.TimezoneOffset = this.getTimezoneOffset();
	
	return o.toJSON();
}

Array.prototype.toJSON = function()
{
	var v = [];

	for(var i=0; i<this.length; i++)
		v.push(this[i] != null ? this[i].toJSON() : 'null') ;

	return "[" + v.join(", ") + "]";
}

if(!Array.prototype.push)
{
	Array.prototype.push = function(o)
	{
		this[this.length] = o;
	}
}

if(!document.head)
{
	var head = document.getElementsByTagName("head");
	
	if(head.length == 1)
	{	
		document.head = head[0];
		document.head.__scriptCount = 0;
		document.head.__scriptLoaded = 0;
		
		document.head.scriptsLoaded = function()
		{
			return document.head.__scriptCount == document.head.__scriptLoaded;
		}
		
		document.head.addScript = function(src)
		{
			var script = document.createElement("script");
			script.type = "text/javascript";
			script.src = src;
			script.onreadystatechange = loadscript;
			
			document.head.__scriptCount++;
			
			document.head.appendChild(script);
		}
		
		function loadscript()
		{
			if(this.readyState == "complete" || this.readyState == "loaded")
				document.head.__scriptLoaded++;
		}
	}
}

// .NET wrapper objects

addNamespace("System.Data");

System.Data.DataSet = function(name)
{
	this.__type = "System.Data.DataSet, System.Data, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
	this.Name = name != null ? name : "";
	this.Tables = new Array();
}

System.Data.DataTable = function(name)
{
	this.__type = "System.Data.DataTable, System.Data, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
	this.Name = name != null ? name : "";
	this.Columns = new Array();
	this.Rows = new Array();
	
	this.addColumn = function(name, type)
	{
		var c = new Object();
		c.Name = name;
		c.__type = type;
		
		this.Columns.push(c);
	}
}

// Browser related members

addNamespace("MS.Browser");

MS.Browser.isIE = (window.navigator.appName.toLowerCase().indexOf('explorer') != -1 || window.navigator.appName.toLowerCase().indexOf('msie') != -1 );

// Debug

addNamespace("MS.Debug");

MS.Debug.enabled = false;
MS.Debug.trace = function(s)
{
}

// Ajax.NET Professional related members

addNamespace("AjaxPro");

AjaxPro.noOperation = function() {}
AjaxPro.cryptProvider = null;
AjaxPro.token = "";
AjaxPro.invoke = function(m, args, c, url)
{
	var o = new Object();
	o.method = m;
	o.args = args;
	o.callback = c[1].length>c[0]?c[1][c[0]] : AjaxPro.noOperation;
	o.context = c[1].length>c[0]+1?c[1][c[0]+1] : null;
	o.session = c[2];
		
	var xml = new XMLHttpRequest();
	var data = "";
	var async = typeof o.callback == "function" && o.callback != AjaxPro.noOperation;
	
	for(attr in o.args)
	{
		if(typeof o.args[attr] != "function")
		{
			data += attr + "=" + (o.args[attr] != null ? o.args[attr].toJSON() : "null") + "\r\n";
		}
	}

	if(MS.Debug.enabled)
		MS.Debug.trace("JSON string: " + data)

	if(async)
		xml.onreadystatechange = doCallback;

	if(data.length == 0) data = " ";	// new String(new Date().getTime());

	xml.open("POST", url, async);
	xml.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
	xml.setRequestHeader("Content-length", data.length);
	xml.setRequestHeader("Ajax-method", o.method);
	xml.setRequestHeader("Ajax-session", o.session);
	xml.setRequestHeader("Ajax-token", AjaxPro.token);
	// xml.setRequestHeader("Ajax-random", new String(new Date().getTime()));		// should be put to AjaxPro.random on load
	
	if(MS.Browser.isIE)
		xml.setRequestHeader("Accept-Encoding", "gzip, deflate");
	else
		xml.setRequestHeader("Connection", "close");		// Mozilla Bug #246651

	if(AjaxPro.cryptProvider != null)
		data = AjaxPro.cryptProvider.encrypt(data);

	if(MS.Debug.enabled)
		MS.Debug.trace("XMLHttpRequest: " + url + "\r\n  Method: " + o.method + "\r\n  Data: " + data)

	xml.send(data);
	
	if(!async)
		return createResponse();

	return true;	
		
	function doCallback()
	{
		if(xml.readyState != 4)
			return;

		if(xml.status == 200)
		{
			o.callback(createResponse());
		}
	}
	
	function createResponse()
	{
		var r = new Object();
		r.url = url;
		r.error = false;
		r.request = o;
		r.value = null;
		r.responseText = xml.responseText;

		if(MS.Debug.enabled)
			MS.Debug.trace("XMLHttpResponse: " + url + "\r\n  Method: " + o.method + "\r\n  Response: " + r.responseText);
			
		if(AjaxPro.cryptProvider != null)
			r.responseText = AjaxPro.cryptProvider.decrypt(r.responseText);

		if(MS.Debug.enabled)
			MS.Debug.trace("JSON string: " + r.responseText);
			
		eval("r.value = " + r.responseText + ";");
			
		return r;
	}
}
