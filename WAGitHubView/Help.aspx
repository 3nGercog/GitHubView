﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GitHubViewSite.Master" CodeBehind="Help.aspx.cs" Inherits="WebAppGitHubView.Help" %>

<asp:Content ID="ContentHelpHeader" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="ContentHelpBody" ContentPlaceHolderID="default" runat="server">
    <div class="help">
        <h3 style="color: peru">Как пользоваться таблицей и ресурсом</h3>
        <div class="text">
            <p>
                Данный ресурс представляет 2 варианта работы с репозиториями:<br />
                1 Для просмотра всех репозиториев (public and private), но при условии проверки подлинности.<br />
                2 Для просмотра public репозиториев без проверки подлинности.
       
            <p>
                Для 1 варианта работы необходимо в строке браузера ввести "localhost/githubview/Default.aspx", где githubview -
номер порта либо название фолдера, после чего загрузится страница где необходимо ввести логин пользователя
github и пароль. При нажатии на кнопку "SUBMIT" загрузиться страница со всеми репозиториями.
       
            </p>
            <p>
                Для второго варианта работы также в строке браузера вводим "localhost/githubview/List.aspx", после чего загрузиться
страница с готовым листом репозиториев. Вы можете добавлять или удалять строки, или изменять значения в таблице,
для этого необходимо нажать кнопку "ACTIVATION" (при первой загрузке текстовое поле будет заблокировано).
Отредактируете таблицу как захотите.
Что бы начать работу с редактированием таблицы (добавление, удаление и редактирование) нужно активировать
текстовое поле при нажатии на клавишу ACTIVATION. После чего текстовое поле активируется и мы можем в него вставлять
нужный(https://github.com) url адрес.
               
                <br />
                Для удаление или изменения ячейки, при условии, что текстовое поле разблокированное, кликнем по нужной ячейке. После
этого в текстовом поле появиться текст нажатой ячейки. Далее можно вставить(ADD), удалить(REMOVE), а если редактировать
то изменить текст в текстовом поле и нажать кнопку EDIT.
           
            </p>
            <p>
                Когда происходит добавление или удаление или редактирование таблицы текстовое поле блокируется.
           
            </p>
            <p>
                Для просмотра информации по репозиториям, которые находятся в таблице, нажмите кнопку "INFO", после чего загрузится
информация о всех репозиториях в таблице. Для возврата на страницу редактирования таблицы нажмите кнопку "BACK" или
с помощью браузера кнопка со стрелочкой в лево.
            </p>
            <p>
                Для правильной публикации веб приложения на IIS посмотрите <a style="text-decoration: none;" href="http://metanit.com/sharp/mvc/13.2.php">пример</a> .
           
            </p>
            <p>
                Если клиентский запрос к вебсайту не содержит имени документа, службы IIS ищут файл, имя которого определено в качестве документа по умолчанию.
Обычно именем документа по умолчанию является Default.htm.
                 Можно <a style="text-decoration: none;" href="https://technet.microsoft.com/ru-ru/library/hh831515.aspx">определить список имен документов</a> по умолчанию в порядке старшинства.
            </p>
        </div>
    </div>
</asp:Content>

