﻿function cell_Click(th) {
    var x = th.id;
    var tr = th.parentNode.parentNode,
        nameRep = tr.getElementsByTagName("td")[1].innerHTML;
    var user = document.getElementById("default_text").value;
    //alert(x + "\n" + nameRep + "\n" + user);
    document.location.href = "Second.aspx" + "?name=" + nameRep + "&user=" + user;
}

function help_Click() {
    document.location.href = "Help.aspx";
}
function cell_list_Click(th) {
    var id = th.getElementsByTagName("td")[0].innerHTML;
    var url = th.getElementsByTagName("td")[1].innerHTML;

    var table = document.getElementById("GridViewUrl");
    var count = table.rows.length - 1;

    var textB = document.getElementById("tb_url");
    var hdF = document.getElementById("hdField").valueOf();
    hdF.value = id;
    //alert(id + "\n" + url + "\n" + count);

    if (textB.disabled) {
        document.location.href = "Show.aspx" + "?cu=" + count;
    }
    else {
        textB.value = url;
    }
}

function bt_back_Click() {
    document.location.href = "List.aspx";
}