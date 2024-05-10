<%--
  Created by IntelliJ IDEA.
  User: Home
  Date: 10/22/2023
  Time: 1:40 AM
  To change this template use File | Settings | File Templates.
--%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ page session="false" %>
<html>
<head>
    <title>Bike Page</title>
    <style type="text/css">
        .tg  {border-collapse:collapse;border-spacing:0;border-color:#ccc;}
        .tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#ccc;color:#333;background-color:#fff;}
        .tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#ccc;color:#333;background-color:#f0f0f0;}
        .tg .tg-4eph{background-color:#f9f9f9}
    </style>
</head>
<body>
<h1>
    Add a Bike
</h1>

<c:url var="addAction" value="/bike/add" ></c:url>

<form:form action="${addAction}" modelAttribute="bike">
    <table>
        <c:if test="${!empty bike.name}">
            <tr>
                <td>
                    <form:label path="id">
                        <spring:message text="ID"/>
                    </form:label>
                </td>
                <td>
                    <form:input path="id" readonly="true" size="8"  disabled="true" />
                    <form:hidden path="id" />
                </td>
            </tr>
        </c:if>
        <tr>
            <td>
                <form:label path="name">
                    <spring:message text="name"/>
                </form:label>
            </td>
            <td>
                <form:input path="name" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="status">
                    <spring:message text="status"/>
                </form:label>
            </td>
            <td>
                <form:input path="status" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="rentPriceForHour">
                    <spring:message text="rentPriceForHour"/>
                </form:label>
            </td>
            <td>
                <form:input path="rentPriceForHour" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="rentPriceForThreeHours">
                    <spring:message text="rentPriceForThreeHours"/>
                </form:label>
            </td>
            <td>
                <form:input path="rentPriceForThreeHours" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="rentPriceForDay">
                    <spring:message text="rentPriceForDay"/>
                </form:label>
            </td>
            <td>
                <form:input path="rentPriceForDay" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <c:if test="${!empty bike.name}">
                    <input type="submit"
                           value="<spring:message text="Edit Bike"/>" />
                </c:if>
                <c:if test="${empty bike.name}">
                    <input type="submit"
                           value="<spring:message text="Add Bike"/>" />
                </c:if>
            </td>
        </tr>
    </table>
</form:form>
<br>
<h3>Bikes List</h3>
<c:if test="${!empty listBikes}">
    <table class="tg">
        <tr>
            <th width="80">Bike ID</th>
            <th width="120">Bike Name</th>
            <th width="120">Bike Status</th>
            <th width="120">Bike rentPriceForHour</th>
            <th width="120">Bike rentPriceForThreeHours</th>
            <th width="120">Bike rentPriceForDay</th>
            <th width="60">Edit</th>
            <th width="60">Delete</th>
        </tr>
        <c:forEach items="${listBikes}" var="bike">
            <tr>
                <td>${bike.id}</td>
                <td>${bike.name}</td>
                <td>${bike.status}</td>
                <td>${bike.rentPriceForHour}</td>
                <td>${bike.rentPriceForThreeHours}</td>
                <td>${bike.rentPriceForDay}</td>
                <td><a href="<c:url value='/bike/edit/${bike.id}' />" >Edit</a></td>
                <td><a href="<c:url value='/bike/remove/${bike.id}' />" >Delete</a></td>
            </tr>
        </c:forEach>
    </table>
</c:if>
</body>
</html>

