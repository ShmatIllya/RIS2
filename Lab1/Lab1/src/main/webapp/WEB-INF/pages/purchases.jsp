<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib uri="http://www.springframework.org/tags" prefix="spring" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib prefix="from" uri="http://www.springframework.org/tags/form" %>
<%@ page session="false" %>
<%@ page contentType="text/html; charset=UTF-8" %>
<meta http-equiv="refresh" content="30">
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"><link rel='stylesheet' type="text/css" href="<c:url value="/css/bootstrap.min.css"/>"/>
    <link rel="stylesheet" type="text/css" href="<c:url value="/css/bootstrap.min.css"/> "/>
</head>
<body>

<br/>
<br/>
<div>
    <c:if test="${!empty listPurchases}">
        <div class="container">
            <div  class="row">
                <div class="col-xs-12 col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2 ">
                    <div class="panel-body">
                        <c:url var="inputAction" value="/purchases/find"/>
                        <form:form action="${inputAction}" commandName="purchase">
                            <fieldset>
                                <div  class="row">
                                    <div class="form-group">
                                        <table>
                                            <tr>
                                                <td class="col-xs-5 col-sm-5 col-md-5  col-lg-5 " >
                                                    <form:input class="form-control" path="name" placeholder="Марка" name="login" type="text"
                                                                autofocus=""/>
                                                </td>
                                                <td class="col-xs-1 col-sm-1 col-md-1  col-lg-1 " >
                                                    <input class="form-control btn-primary" type="submit"
                                                           value="<spring:message text="Поиск"/>"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </fieldset>
                        </form:form>
                    </div>
                    <table class="table table-bordered">
                        <tr class="bg-info row">
                            <th class="col-xs-1 col-sm-1 col-md-1  col-lg-1 ">№</th>
                            <th class="col-xs-3 col-sm-3 col-md-3  col-lg-3 ">Марка</th>
                            <th class="col-xs-3 col-sm-3 col-md-3  col-lg-3 ">Модель</th>
                            <th class="col-xs-5 col-sm-5 col-md-5  col-lg-5 ">Количество</th>
                            <th></th>
                            <th></th>
                        </tr>
                        <c:forEach items="${listPurchases}" var="purchase">
                            <tr class="row">
                                <td class="col-xs-1 col-sm-1 col-md-1  col-lg-1 ">${purchase.id}</td>
                                <td class="col-xs-3 col-sm-3 col-md-3  col-lg-3 "><a href="/purchaseinfo/${purchase.id}">${purchase.name}</a></td>
                                <td class="col-xs-5 col-sm-5 col-md-5  col-lg-5 " >${purchase.model}</td>
                                <td class="col-xs-5 col-sm-5 col-md-5  col-lg-5 " >${purchase.amount}</td>
                                <td><a href="<c:url value='/edit/${purchase.id}'/>">Изменить</a></td>
                                <td><a href="<c:url value='/remove/${purchase.id}'/>">Удалить</a></td>
                            </tr>
                        </c:forEach>
                    </table>
                </div>
            </div>
        </div>
    </c:if>
</div>


<c:url var="addAction" value="/purchases/add"/>
<div class="container">
    <div  class="row">
        <div class="col-xs-12 col-sm-10 col-sm-offset-1 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2 ">
            <form:form action="${addAction}" commandName="purchase">
                <table class="table">
                    <c:if test="${!empty purchase.name}">
                        <tr class="bg-info">
                            <td>
                                <form:label path="id">
                                    <spring:message text="ID"/>
                                </form:label>
                            </td>
                            <td class="form-group">
                                <form:input path="id" readonly="true" size="8" disabled="true"/>
                                <form:hidden path="id"/>
                            </td>
                        </tr>
                    </c:if>
                    <tr>
                        <td>
                            <form:label path="name">
                                <spring:message text="Марка"/>
                            </form:label>
                        </td>
                        <td class="form-group">
                            <form:input path="name"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <form:label path="model">
                                <spring:message text="Модель"/>
                            </form:label>
                        </td>
                        <td class="form-group">
                            <form:input path="model"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <form:label path="amount">
                                <spring:message text="Количество"/>
                            </form:label>
                        </td>
                        <td class="form-group">
                            <form:input path="amount"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <c:if test="${!empty purchase.name}">
                                <input class="btn btn-primary" type="submit"
                                       value="<spring:message text="Изменить заказ"/>"/>
                            </c:if>
                            <c:if test="${empty purchase.name}">
                                <input class="btn btn-primary" type="submit"
                                       value="<spring:message text="Добавить заказ"/>"/>
                            </c:if>
                        </td>
                    </tr>
                </table>
            </form:form>
        </div>
    </div>
</div>
</body>
</html>
