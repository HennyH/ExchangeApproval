<%@ page language="java" contentType="text/html; charset=UTF-8"
         pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
  <title>file upload</title>
</head>
<body>
<form action="/upload" enctype="multipart/form-data" method="post">
  upload user：<input type="text" name="username"><br/>
  upload file1:<input type="file" name="file1"><br/>
  <input type="submit" value="submiting">
</form>
</body>
</html>