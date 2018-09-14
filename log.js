/*
    <script type="text/javascript">
        var ___log = new Worker('homeui/js/log.js');
        console.log = function (val1, val2) { ___log.postMessage({ val1: val1, val2: val2 }); };
        if ('ontouchstart' in window) { } else { ___log.postMessage('view'); }
    </script>

 */

var _view = false;
var _ws;
var _id = 'ws-logid-xxx-xxxx-4xxx-yxxxxxxxx'.replace(/[xy]/g, function (c) {
    var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
    return v.toString(16);
});

if ('WebSocket' in self) {
    _ws = new WebSocket('ws://192.168.81.216:56789');
    _ws.onopen = function () { f_send1(_id); };
    _ws.onclose = function () { };
    _ws.onmessage = function (e) { if (_view) console.log(e.data); };
}

function f_send1(data) {
    if (_ws && data && _view == false) {
        if (typeof data == 'string')
            _ws.send(data);
        else
            _ws.send(JSON.stringify(data));
    }
}

function f_send2(data1, data2) {
    if (_ws && _view == false) {
        var s = '';
        if (data1) { if (typeof data1 == 'string') s = data1; else s = JSON.stringify(data1); }
        if (data2) { if (typeof data2 == 'string') s += '\r\n           ===== ' + data2; else s += '\r\n           ===== ' + JSON.stringify(data2); }
        _ws.send(s);
    }
}

self.addEventListener('message', function (e) {
    var data = e.data;
    switch (data) {
        case 'view':
            _view = true;
            console.log('VIEW -> LOGGGGGGGGGGGGGGGGGGGGGGGGGGGGG:');
            break;
        default:
            if (data.val2)
                f_send2(data.val1, data.val2);
            else
                f_send1(data.val1);
            break;
    };
}, false);