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
    <title>Contract Page</title>
    <style type="text/css">
        .tg  {border-collapse:collapse;border-spacing:0;border-color:#ccc;}
        .tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#ccc;color:#333;background-color:#fff;}
        .tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#ccc;color:#333;background-color:#f0f0f0;}
        .tg .tg-4eph{background-color:#f9f9f9}
    </style>
</head>
<body>
<h1>
    Add a Contract
</h1>

<c:url var="addAction" value="/contract/add" ></c:url>

<form:form action="${addAction}" modelAttribute="contract">
    <table>
        <c:if test="${!empty contract.startTime}">
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
                <form:label path="customerIDInt">
                    <spring:message text="customerIDInt"/>
                </form:label>
            </td>
            <td>
                <form:input path="customerIDInt" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="bikeIDInt">
                    <spring:message text="bikeIDInt"/>
                </form:label>
            </td>
            <td>
                <form:input path="bikeIDInt" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="rentDuration">
                    <spring:message text="rentDuration"/>
                </form:label>
            </td>
            <td>
                <form:input path="rentDuration" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="startTime">
                    <spring:message text="startTime"/>
                </form:label>
            </td>
            <td>
                <form:input path="startTime" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="endTime">
                    <spring:message text="endTime"/>
                </form:label>
            </td>
            <td>
                <form:input path="endTime" />
            </td>
        </tr>
        <tr>
            <td>
                <form:label path="totalAmount">
                    <spring:message text="totalAmount"/>
                </form:label>
            </td>
            <td>
                <form:input path="totalAmount" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <c:if test="${!empty contract.startTime}">
                    <input type="submit"
                           value="<spring:message text="Edit Contract"/>" />
                </c:if>
                <c:if test="${empty contract.startTime}">
                    <input type="submit"
                           value="<spring:message text="Add Contract"/>" />
                </c:if>
            </td>
        </tr>
    </table>
</form:form>
<br>
<h3>Contracts List</h3>
<c:if test="${!empty listContracts}">
    <table class="tg">
        <tr>
            <th width="80">Contract ID</th>
            <th width="120">Contract customerId</th>
            <th width="120">Contract bikeId</th>
            <th width="120">Contract rentDuration</th>
            <th width="120">Contract startTime</th>
            <th width="120">Contract endTime</th>
            <th width="120">Contract totalAmount</th>
            <th width="60">Edit</th>
            <th width="60">Delete</th>
        </tr>
        <c:forEach items="${listContracts}" var="contract">
            <tr>
                <td>${contract.id}</td>
                <td>${contract.customerId}</td>
                <td>${contract.bikeId}</td>
                <td>${contract.rentDuration}</td>
                <td>${contract.startTime}</td>
                <td>${contract.endTime}</td>
                <td>${contract.totalAmount}</td>
                <td><a href="<c:url value='/contract/edit/${contract.id}' />" >Edit</a></td>
                <td><a href="<c:url value='/contract/remove/${contract.id}' />" >Delete</a></td>
            </tr>
        </c:forEach>
    </table>
</c:if>
</body>
</html>

