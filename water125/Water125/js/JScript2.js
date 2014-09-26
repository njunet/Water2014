var polylinePointsArray_A = new Array(); //定义点阵数组
var polylinePointsArray_B = new Array();
var section_num = 31; //增加路段时更改数子

var weight = 5;
var Grade = 0;
//A 代表r或u,B代表l或d
var polylineA = []; //定义线条数组
var polylineB = [];
var polycircle = new Array(section_num + 1); //定义事件圆数组
var radius;
var avr1;
var opts0 = {
    strokeColor: "#000000",
    strokeWeight: 3,
    strokeOpacity: 1,
    strokeStyle: 'dashed'
}

function hello2() {
    alert('nihao');
}
function draw_traffic(section_speed, command, command_pre) {
    //画交通流量前判断地图级别
    var num = map.getZoom();
    document.getElementById('num').value = map.getZoom();
    var avrg = 0;
    var cnt1 = 0, cnt2 = 0, cnt3 = 0, changtong = 0;
    var radius_all = 0;
    //暂时取消分级
    if (document.getElementById('num').value >= 14) Grade = 1;
    else Grade = 0;
    remove_lines();
    initial_lines(Grade); //初始化时设子线条级别


    if (command_pre == 1) {
        for (i = 2; i <= 63; i++)
            //section_speed[i] = parseFloat(section_speed[i]) / 2;
            section_speed[i] = section_speed[i+124];
    }
    if (command_pre == 2) {
        for (i = 2; i <= 63; i++)
        //section_speed[i] = parseFloat(section_speed[i]) / 2;
            section_speed[i] = section_speed[i + 186];
    }
    if (command_pre == 3) {
        for (i = 2; i <= 63; i++)
        //section_speed[i] = parseFloat(section_speed[i]) / 2;
            section_speed[i] = section_speed[i + 248];
    }

    //根据速度画流量   
    for (i = 1; i <= section_num; i++) {
        shijian = i;
        polylineA[i] = new BMap.Polyline(polylinePointsArray_A[i], { strokeColor: color_choice(section_speed[2 * i]), strokeWeight: weight, strokeOpacity: 1 })
        map.addOverlay(polylineA[i]);
        polylineB[i] = new BMap.Polyline(polylinePointsArray_B[i], { strokeColor: color_choice(section_speed[2 * i + 1]), strokeWeight: weight, strokeOpacity: 1 })
        map.addOverlay(polylineB[i]);
        avrg = avrg + parseFloat(section_speed[2 * i]) + parseFloat(section_speed[2 * i + 1]);

        //根据速度画警示圈
        if (command == 1) {
            if (section_speed[2 * i] <= 50 && section_speed[2 * i + 1] <= 50) {

                radius = (50 - section_speed[2 * i] / 4 - section_speed[2 * i + 1] / 4) * 50 + 1000;
                if (polycircle[i] != null) map.removeOverlay(polycircle[i]);
                polycircle[i] = new BMap.Circle(polylinePointsArray_A[i][3], radius, opts0);
                map.addOverlay(polycircle[i]);
                radius_all = radius_all + 2;
            }
            else if (section_speed[2 * i] <= 50 && section_speed[2 * i + 1] > 50) {
                radius = (50 - section_speed[2 * i]) * 50 + 1000;
                if (polycircle[i] != null) map.removeOverlay(polycircle[i]);
                polycircle[i] = new BMap.Circle(polylinePointsArray_A[i][3], radius, opts0);
                map.addOverlay(polycircle[i]);
                radius_all++;
            }
            else if (section_speed[2 * i] > 50 && section_speed[2 * i + 1] <= 50) {
                radius = (50 - section_speed[2 * i + 1]) * 50 + 1000;
                if (polycircle[i] != null) map.removeOverlay(polycircle[i]);
                polycircle[i] = new BMap.Circle(polylinePointsArray_A[i][3], radius, opts0);
                map.addOverlay(polycircle[i]);
                radius_all++;
            }
            else if (polycircle[i] != null) {
                map.removeOverlay(polycircle[i]);
            }
        }
        else {
            for (j = 1; j <= section_num; j++)
                if (polycircle[j] != null) map.removeOverlay(polycircle[j]);
            radius_all = 0;
        }



        if (section_speed[2 * i] >= 90) cnt1++;
        else if (section_speed[2 * i] >= 60) cnt2++;
        if (section_speed[2 * i + 1] >= 90) cnt1++;
        else if (section_speed[2 * i + 1] >= 60) cnt2++;
    }

    avrg = avrg / (2 * section_num);
    avr1 = avrg;
    //document.getElementById('avr').value = "路网平均车速" + Math.round(avrg * 10) / 10 + " km/h";
    document.getElementById('avr').value = "是正常行使时间的" + Math.round(120 / avrg * 10) / 10 + "倍";

    cnt1 = Math.round(cnt1 / (2 * section_num) * 1000) / 10;
    document.getElementById('cnt1').value = cnt1 + "%";
    cnt2 = Math.round(cnt2 / (2 * section_num) * 1000) / 10;
    document.getElementById('cnt2').value = cnt2 + "%";
    cnt3 = Math.round((100 - cnt1 - cnt2) * 10) / 10;
    document.getElementById('cnt3').value = cnt3 + "%";
    changtong = Math.round((10 * cnt1 + 5 * cnt2 + 1 * cnt3) / 10) / 10;
    document.getElementById('changtong').value = changtong;
    //畅通指数矩形
    jCanvaScript.start('csser_canvas');
    jCanvaScript.rect(0, 0, 230, 25, color_choice(avr1), 1);
    jCanvaScript.start('csser_canvas');
//    //异常警报圆
//    if (command == 1) {
//        var c = document.getElementById("csser_canvas1");
//        var cxt = c.getContext("2d");
//        cxt.fillStyle = "#FFFFFF";
//        cxt.beginPath();
//        cxt.arc(100, 100, 100, 0, Math.PI * 2, true);
//        cxt.closePath();
//        cxt.fill();
//        var c = document.getElementById("csser_canvas1");
//        var cxt = c.getContext("2d");
//        cxt.fillStyle = "#FF0000";
//        cxt.beginPath();
//        cxt.arc(100, 100, radius_all * 4, 0, Math.PI * 2, true);
//        cxt.closePath();
//        cxt.fill();
//    }

}


//移除所有线
function remove_lines() {
    for (i = 1; i < polylineA.length; i++) {
        map.removeOverlay(polylineA[i]);
        map.removeOverlay(polylineB[i]);
    }
}


//画实心矩形
function drawFilledRect(x1, y1, x2, y2, color) {
    document.write("border='0' cellspacing=0  cellpadding=0 style='position: absolute;left: " + (x1) + "; top: " + (y1) + ";background-color: " + color + "' width=" + (x2 - x1) + " height=" + (y2 - y1));
}


//单路段将经纬度转化为点阵
function initial_line(mapgrade, road_section, polylinePointsArray) {
    polylinePointsArray.splice(0);
    for (var i = 0; i < (road_section[mapgrade].length) / 2; i++) {
        var x = road_section[mapgrade][i * 2];
        var y = road_section[mapgrade][i * 2 + 1];
        polylinePointsArray[i] = new BMap.Point(x, y);
    }
}


//全路段转化为点阵
function initial_lines(mapgrade) {
    for (i = 1; i <= section_num; i++) {
        polylinePointsArray_A[i] = new Array();
        polylinePointsArray_B[i] = new Array();
    }
    initial_line(mapgrade, road_section1_A, polylinePointsArray_A[1]);
    initial_line(mapgrade, road_section1_B, polylinePointsArray_B[1]);
    initial_line(mapgrade, road_section2_A, polylinePointsArray_A[2]);
    initial_line(mapgrade, road_section2_B, polylinePointsArray_B[2]);
    initial_line(mapgrade, road_section3_A, polylinePointsArray_A[3]);
    initial_line(mapgrade, road_section3_B, polylinePointsArray_B[3]);
    initial_line(mapgrade, road_section4_A, polylinePointsArray_A[4]);
    initial_line(mapgrade, road_section4_B, polylinePointsArray_B[4]);
    initial_line(mapgrade, road_section5_A, polylinePointsArray_A[5]);
    initial_line(mapgrade, road_section5_B, polylinePointsArray_B[5]);
    initial_line(mapgrade, road_section6_A, polylinePointsArray_A[6]);
    initial_line(mapgrade, road_section6_B, polylinePointsArray_B[6]);
    initial_line(mapgrade, road_section7_A, polylinePointsArray_A[7]);
    initial_line(mapgrade, road_section7_B, polylinePointsArray_B[7]);
    initial_line(mapgrade, road_section8_A, polylinePointsArray_A[8]);
    initial_line(mapgrade, road_section8_B, polylinePointsArray_B[8]);
    initial_line(mapgrade, road_section9_A, polylinePointsArray_A[9]);
    initial_line(mapgrade, road_section9_B, polylinePointsArray_B[9]);
    initial_line(mapgrade, road_section10_A, polylinePointsArray_A[10]);
    initial_line(mapgrade, road_section10_B, polylinePointsArray_B[10]);
    initial_line(mapgrade, road_section11_A, polylinePointsArray_A[11]);
    initial_line(mapgrade, road_section11_B, polylinePointsArray_B[11]);
    initial_line(mapgrade, road_section12_A, polylinePointsArray_A[12]);
    initial_line(mapgrade, road_section12_B, polylinePointsArray_B[12]);
    initial_line(mapgrade, road_section13_A, polylinePointsArray_A[13]);
    initial_line(mapgrade, road_section13_B, polylinePointsArray_B[13]);
    initial_line(mapgrade, road_section14_A, polylinePointsArray_A[14]);
    initial_line(mapgrade, road_section14_B, polylinePointsArray_B[14]);
    initial_line(mapgrade, road_section15_A, polylinePointsArray_A[15]);
    initial_line(mapgrade, road_section15_B, polylinePointsArray_B[15]);
    initial_line(mapgrade, road_section16_A, polylinePointsArray_A[16]);
    initial_line(mapgrade, road_section16_B, polylinePointsArray_B[16]);
    initial_line(mapgrade, road_section17_A, polylinePointsArray_A[17]);
    initial_line(mapgrade, road_section17_B, polylinePointsArray_B[17]);
    initial_line(mapgrade, road_section18_A, polylinePointsArray_A[18]);
    initial_line(mapgrade, road_section18_B, polylinePointsArray_B[18]);
    initial_line(mapgrade, road_section19_A, polylinePointsArray_A[19]);
    initial_line(mapgrade, road_section19_B, polylinePointsArray_B[19]);
    initial_line(mapgrade, road_section20_A, polylinePointsArray_A[20]);
    initial_line(mapgrade, road_section20_B, polylinePointsArray_B[20]);
    initial_line(mapgrade, road_section21_A, polylinePointsArray_A[21]);
    initial_line(mapgrade, road_section21_B, polylinePointsArray_B[21]);
    initial_line(mapgrade, road_section22_A, polylinePointsArray_A[22]);
    initial_line(mapgrade, road_section22_B, polylinePointsArray_B[22]);
    initial_line(mapgrade, road_section23_A, polylinePointsArray_A[23]);
    initial_line(mapgrade, road_section23_B, polylinePointsArray_B[23]);
    initial_line(mapgrade, road_section24_A, polylinePointsArray_A[24]);
    initial_line(mapgrade, road_section24_B, polylinePointsArray_B[24]);
    initial_line(mapgrade, road_section25_A, polylinePointsArray_A[25]);
    initial_line(mapgrade, road_section25_B, polylinePointsArray_B[25]);
    initial_line(mapgrade, road_section26_A, polylinePointsArray_A[26]);
    initial_line(mapgrade, road_section26_B, polylinePointsArray_B[26]);
    initial_line(mapgrade, road_section27_A, polylinePointsArray_A[27]);
    initial_line(mapgrade, road_section27_B, polylinePointsArray_B[27]);
    initial_line(mapgrade, road_section28_A, polylinePointsArray_A[28]);
    initial_line(mapgrade, road_section28_B, polylinePointsArray_B[28]);
    initial_line(mapgrade, road_section29_A, polylinePointsArray_A[29]);
    initial_line(mapgrade, road_section29_B, polylinePointsArray_B[29]);
    initial_line(mapgrade, road_section30_A, polylinePointsArray_A[30]);
    initial_line(mapgrade, road_section30_B, polylinePointsArray_B[30]);
    initial_line(mapgrade, road_section31_A, polylinePointsArray_A[31]);
    initial_line(mapgrade, road_section31_B, polylinePointsArray_B[31]);
}

function Timeinit(mydate) {
    mydate.setFullYear(2013, 2, 11);
    mydate.setHours(0, 0, 0);
    return mydate;
}


function Timeaddmins(mydate, mins) {
    myDate.setMinutes(myDate.getMinutes() + mins);
    return mydate;
}


function TimetoString(mydate) {
    var mydatestr = mydate.toDateString();
    var mytimestr = mydate.toTimeString();
    mytimestr = mytimestr.substr(0, 8);
    return mydatestr + " " + mytimestr;
}


function color_choice(speed) {
    var color;
    if (speed >= 100)
        color = "#008000";
    else if (speed >= 90)
        color = "#20c000";
    else if (speed >= 80)
        color = "#ffff00";
    else if (speed > 70)
        color = "#ffc000";
    else if (speed > 60)
        color = "#ffa000";
    else if (speed > 50)
        color = "#ff6000";
    else color = "#c00000";

    return color;
}


var Marker_location = new Array([0, 0],
                                    [118.889127, 32.117446],
                                    [118.859231, 32.109616],
                                    [118.830486, 32.223075],
                                    [118.80289, 32.199613],
                                    [118.860381, 32.33932],
                                    [118.86728, 32.311005],
                                    [118.977664, 32.335415],
                                    [118.981114, 32.309052],
                                    [119.124842, 32.313934],
                                    [119.117943, 32.288542],
                                    [119.28007, 32.328581],
                                    [119.286969, 32.303192],
                                    [119.438746, 32.37836],
                                    [119.447945, 32.331509],
                                    [119.562928, 32.415432],
                                    [119.572127, 32.374456],
                                    [119.700908, 32.425185],
                                    [119.691709, 32.386165],
                                    [119.813591, 32.386165],
                                    [119.802093, 32.343224],
                                    [119.919376, 32.372505],
                                    [119.907877, 32.31784],
                                    [120.011362, 32.313934],
                                    [119.963069, 32.284635],
                                    [120.078052, 32.233827],
                                    [120.02286, 32.196679],
                                    [120.170039, 32.18299],
                                    [120.119446, 32.139951],
                                    [120.264325, 32.067522],
                                    [120.216032, 32.05773],
                                    [120.328716, 31.930336],
                                    [120.275823, 31.914644],
                                    [118.953518, 32.083187],
                                    [118.951218, 32.058709],
                                    [119.100696, 32.074376],
                                    [119.088048, 32.046957],
                                    [119.232927, 32.059689],
                                    [119.229477, 32.030306],
                                    [119.327213, 32.05773],
                                    [119.327213, 32.026388],
                                    [119.48014, 32.06948],
                                    [119.477841, 32.034225],
                                    [119.602022, 32.053813],
                                    [119.595123, 32.02247],
                                    [119.733103, 31.969553],
                                    [119.707807, 31.940142],
                                    [119.82049, 31.930336],
                                    [119.804393, 31.902874],
                                    [119.949271, 31.877366],
                                    [119.928574, 31.845962],
                                    [120.059655, 31.824365],
                                    [120.036658, 31.796871],
                                    [120.16544, 31.775263],
                                    [120.183837, 31.745789],
                                    [120.264325, 31.814547],
                                    [120.282722, 31.78705],
                                    [119.390453, 32.300263],
                                    [119.353659, 32.288542],
                                    [119.399652, 32.210367],
                                    [119.355958, 32.208412],
                                    [119.441046, 32.122339],
                                    [119.399652, 32.12821]);

var road_section6_A = new Array([118.845433, 32.173699,
                                       118.85032, 32.165385,
                                      118.856357, 32.155848,
                                      118.860094, 32.143865,
                                      118.865843, 32.132368,
                                      118.873892, 32.122094,
                                      118.880503, 32.109127,
                                      118.883953, 32.100563,
                                      118.888408, 32.089306,
                                      118.89617, 32.078537,
                                      118.903069, 32.068501],
                                      [118.831132, 32.190079,
                                      118.83875, 32.181584,
                                   118.854273, 32.156582,
                                   118.858369, 32.145882,
                                   118.859375, 32.143192,
                                   118.860381, 32.140257,
                                   118.861819, 32.137199,
                                   118.868933, 32.126314,
                                   118.87497, 32.11818,
                                   118.878204, 32.112002,
                                   118.882516, 32.100746,
                                   118.886612, 32.089918,
                                   118.888049, 32.087348,
                                   118.900266, 32.071194,
                                   118.902278, 32.068654]);


var road_section6_B = new Array([118.899907, 32.06743,
                                    118.888408, 32.083585,
                                    118.882372, 32.093374,
                                    118.878347, 32.107078,
                                    118.871736, 32.119066,
                                    118.865412, 32.127629,
                                    118.85765, 32.140349,
                                    118.854488, 32.152822,
                                    118.848452, 32.162115,
                                    118.844715, 32.168962],
                                    [
                                    118.901488, 32.068257,
                                    118.898972, 32.071378,
                                    118.888408, 32.085512,
                                    118.886037, 32.089428,
                                    118.884671, 32.091876,
                                    118.881725, 32.100563,
                                    118.877844, 32.110595,
                                    118.874179, 32.117385,
                                    118.866849, 32.12717,
                                    118.863256, 32.133041,
                                    118.8588, 32.141113,
                                    118.857794, 32.14417,
                                    118.854848, 32.152914,
                                    118.850177, 32.16184,
                                    118.840259, 32.177489,
                                    118.834869, 32.18464,
                                    118.828689, 32.191301]);


var road_section5_A = new Array([118.777593, 32.258013,
                                      118.786217, 32.251662,
                                      118.797715, 32.243111,
                                      118.80404, 32.23456,
                                      118.809789, 32.225274,
                                      118.814676, 32.216721,
                                      118.818125, 32.208167,
                                      118.824162, 32.199124,
                                      118.832498, 32.191057,
                                      118.839972, 32.181523,
                                      118.845433, 32.173699],
                                      [118.775581, 32.259906,
                                   118.776012, 32.258135,
                                   118.77745, 32.256181,
                                   118.779678, 32.254654,
                                   118.783558, 32.252517,
                                   118.787439, 32.250318,
                                   118.792757, 32.246715,
                                   118.796422, 32.243172,
                                   118.800806, 32.237369,
                                   118.809358, 32.223747,
                                   118.81331, 32.21556,
                                   118.815538, 32.21,
                                   118.818125, 32.205173,
                                   118.822365, 32.199246,
                                   118.831132, 32.190079]);

var road_section5_B = new Array([118.844715, 32.168962,
                                    118.838391, 32.178497,
                                    118.82833, 32.190721,
                                    118.817981, 32.201476,
                                    118.81022, 32.218096,
                                    118.801596, 32.232269,
                                    118.794122, 32.242286,
                                    118.784924, 32.248883,
                                    118.777162, 32.254013,
                                    118.772994, 32.260211],
                                    [
                                    118.828689, 32.191301,
                                    118.822365, 32.197718,
                                    118.81755, 32.204134,
                                    118.813813, 32.211345,
                                    118.810436, 32.219287,
                                    118.80828, 32.223747,
                                    118.801093, 32.235109,
                                    118.797141, 32.240607,
                                    118.795847, 32.242317,
                                    118.792972, 32.245676,
                                    118.786577, 32.249768,
                                    118.779031, 32.253311,
                                    118.775725, 32.256364,
                                    118.775294, 32.257891]);

var road_section4_A = new Array([118.772994, 32.260211,
                                      118.774431, 32.266806,
                                      118.810939, 32.302216,
                                      118.83336, 32.315399,
                                      118.854057, 32.321502,
                                      118.869867, 32.329801],
                                      [118.774791, 32.258563,
                                      118.77436, 32.262349,
                                      118.775653, 32.265585,
                                      118.777953, 32.268272,
                                      118.796134, 32.286283,
                                      118.809645, 32.299591,
                                      118.814532, 32.303192,
                                      118.824593, 32.309174,
                                      118.832785, 32.314972,
                                      118.839541, 32.317596,
                                      118.853985, 32.320831,
                                      118.862034, 32.323882]);

var road_section3_A = new Array([118.869867, 32.329801,
                                   118.885965, 32.333706,
                                   118.896888, 32.340296,
                                   118.9035, 32.343468,
                                   118.929946, 32.339808,
                                   118.966166, 32.327116,
                                   118.971915, 32.324919,
                                   118.993187, 32.330777,
                                   119.017908, 32.326384],
                                  [118.862034, 32.323882,
                                  118.868646, 32.327482,
                                  118.887259, 32.33334,
                                  118.898469, 32.340723,
                                  118.904003, 32.342248,
                                  118.910686, 32.342309,
                                  118.92549, 32.339136,
                                  118.929659, 32.338221,
                                  118.93857, 32.335048,
                                  118.954811, 32.328947,
                                  118.968178, 32.32437,
                                  118.971915, 32.32437]);

var road_section2_A = new Array([
                                   119.017908, 32.326384,
                                   119.025382, 32.322722,
                                   119.059877, 32.319549,
                                   119.109032, 32.304657,
                                  119.157325, 32.303925,
                                  119.2427, 32.292693],
                                  [118.971915, 32.32437,
                                  118.992396, 32.329496,
                                  118.995846, 32.329679,
                                  119.013956, 32.32614,
                                  119.022004, 32.322539,
                                  119.052834, 32.319854,
                                  119.058655, 32.318817,
                                  119.074322, 32.313629,
                                  119.084383, 32.311127,
                                  119.106876, 32.304169,
                                  119.112913, 32.303437,
                                  119.153157, 32.303253]);

var road_section1_A = new Array([
                                  119.2427, 32.292693,
                                  119.292718, 32.326628,
                                  119.34676, 32.335415,
                                  119.355096, 32.342248,
                                  119.371194, 32.347129],
                                 [119.153157, 32.303253,
                                 119.181112, 32.298553,
                                 119.191101, 32.296905,
                                 119.231058, 32.292449,
                                 119.245718, 32.292388,
                                 119.281004, 32.317413,
                                 119.29473, 32.326262,
                                 119.322613, 32.331387,
                                 119.347191, 32.335171,
                                 119.354665, 32.341577,
                                 119.370475, 32.346092]);

var road_section28_A = new Array([119.370475, 32.346092,
                                  119.371769, 32.347373,
                                  119.39419, 32.353962,
                                  119.407126, 32.356402,
                                  119.425523, 32.357866,
                                  119.443921, 32.357866,
                                  119.449095, 32.357378,
                                   119.474966, 32.370553
                                 ],
                                 []);
var road_section27_A = new Array([119.474966, 32.370553,
                                  119.490201, 32.369333,
                                  119.51291, 32.391532,
                                  119.51866, 32.393727,
                                  119.566378, 32.395678,
                                  119.58305, 32.40836
                                 ],
                                 []);
var road_section26_A = new Array([119.58305, 32.40836,
                                  119.637092, 32.419089,
                                  119.666125, 32.418114,
                                  119.692284, 32.415676,
                                  119.714418, 32.409823
                                 ],
                                 []);
var road_section25_A = new Array([119.714418, 32.409823,
                                      119.727929, 32.401044,
                                  119.77306, 32.37348,
                                  119.792319, 32.370309,
                                  119.815029, 32.372017,
                                  119.828826, 32.374456
                                 ],
                                 []);
var road_section24_A = new Array([
                                  119.828826, 32.374456,
                                  119.839175, 32.373236,
                                  119.861884, 32.370065,
                                  119.886031, 32.362014,
                                  119.925125, 32.350545,
                                  119.93806, 32.342492,
                                  119.957608, 32.324187
                                 ],
                                 []);
var road_section23_A = new Array([119.957608, 32.324187,
                                  119.968818, 32.319793,
                                  119.978592, 32.315887,
                                  119.986928, 32.30661,
                                  119.993252, 32.29074,
                                  120.003888, 32.275111,
                                  120.00935, 32.265585,
                                  120.013087, 32.257036
                                  ],
                                 []);
var road_section22_A = new Array([120.013087, 32.257036,
                                  120.019698, 32.250684,
                                  120.033209, 32.243355,
                                  120.045857, 32.232849,
                                  120.053906, 32.224297,
                                  120.065117, 32.215744,
                                  120.082077, 32.206456,
                                  120.095587, 32.202546,
                                  120.106511, 32.195946,
                                  120.115134, 32.186901,
                                  120.123183, 32.179811
                                  ],
                                 []);
var road_section21_A = new Array([
                                  120.123183, 32.179811,
                                  120.139856, 32.174677,
                                  120.151642, 32.168564,
                                  120.164002, 32.16025,
                                  120.218044, 32.138239,
                                  120.223793, 32.136771
                                  ],
                                 []);


var road_section4_B = new Array([118.777881, 32.258013,
                                  118.777019, 32.261677,
                                  118.776444, 32.263631,
                                  118.784492, 32.270959,
                                  118.798578, 32.283902,
                                  118.812376, 32.298798,
                                  118.822437, 32.306855,
                                  118.836522, 32.315643,
                                  118.849745, 32.318084,
                                  118.860956, 32.321746,
                                  118.872742, 32.326628],
                                 [118.775941, 32.258929,
                                 118.775366, 32.261005,
                                 118.775797, 32.26357,
                                 118.776947, 32.265707,
                                 118.779534, 32.268455,
                                 118.787654, 32.275904,
                                 118.798147, 32.286405,
                                 118.810723, 32.299286,
                                 118.816975, 32.30362,
                                 118.824593, 32.307831,
                                 118.83027, 32.31192,
                                 118.831779, 32.313568]);
var road_section3_B = new Array([
                                  118.872742, 32.326628,
                                  118.887115, 32.331021,
                                  118.892577, 32.333706,
                                  118.900625, 32.33932,
                                  118.909537, 32.34054,
                                   118.927934, 32.336635,
                                   118.964728, 32.323455,
                                   118.970765, 32.322722,
                                   118.994049, 32.327604,
                                   119.016183, 32.322722,
                                   119.020783, 32.320281],
                                 [118.831779, 32.313568,
                                 118.836235, 32.315399,
                                 118.842559, 32.317291,
                                 118.848524, 32.318573,
                                 118.855638, 32.320098,
                                 118.868215, 32.326018,
                                 118.876191, 32.328825,
                                 118.889055, 32.332974,
                                 118.900482, 32.340357,
                                 118.907596, 32.341272,
                                 118.926065, 32.338282,
                                 118.957398, 32.326933]);
var road_section2_B = new Array([
                                   119.020783, 32.320281,
                                   119.054703, 32.317596,
                                   119.10472, 32.302216,
                                   119.155025, 32.301239,
                                   119.17371, 32.297577,
                                   119.21223, 32.292449,
                                   119.242988, 32.289763],
                                  [118.957398, 32.326933,
                                  118.968968, 32.323394,
                                  118.994696, 32.328642,
                                  119.013237, 32.325407,
                                  119.020998, 32.32199,
                                  119.057721, 32.318145,
                                  119.075184, 32.312409,
                                  119.084095, 32.310272,
                                  119.104505, 32.304108,
                                  119.108817, 32.302948,
                                  119.154091, 32.302338,
                                  119.183484, 32.297272]);
var road_section1_B = new Array([
                                   119.242988, 32.289763,
                                   119.293868, 32.323455,
                                   119.347047, 32.33273,
                                   119.351647, 32.336635,
                                   119.356821, 32.339075,
                                   119.359408, 32.341272,
                                   119.369182, 32.343468],
                                  [119.183484, 32.297272,
                                  119.18988, 32.295929,
                                  119.228399, 32.291594,
                                  119.245934, 32.291533,
                                  119.27971, 32.31546,
                                  119.295233, 32.325346,
                                  119.303785, 32.327116,
                                  119.347191, 32.334194,
                                  119.3487, 32.334865,
                                  119.355958, 32.340479,
                                  119.370403, 32.345055]);
var road_section28_B = new Array([119.370403, 32.345055,
                                   119.374068, 32.3442,
                                   119.395053, 32.351033,
                                   119.426673, 32.355182,
                                   119.44737, 32.354206,
                                   119.478415, 32.366893
                                   ],
                                  []);
var road_section27_B = new Array([119.478415, 32.366893,
                                     119.493076, 32.365673,
                                   119.51291, 32.386409,
                                   119.519809, 32.3908,
                                   119.566665, 32.393239,
                                   119.587362, 32.405921
                                   ],
                                  []);
var road_section26_B = new Array([
                                   119.587362, 32.405921,
                                   119.63623, 32.415432,
                                   119.689409, 32.413725,
                                   119.714418, 32.405677

                                   ],
                                  []);
var road_section25_B = new Array([119.714418, 32.405677,
                                    119.752938, 32.379335,
                                   119.766736, 32.372261,
                                   119.778521, 32.368601,
                                   119.793469, 32.367137,
                                   119.826527, 32.370553
                                   ],
                                  []);
var road_section24_B = new Array([119.826527, 32.370553,
                                   119.841762, 32.369821,
                                   119.85901, 32.365917,
                                   119.923688, 32.347861,
                                   119.957608, 32.321014
                                   ],
                                  []);
var road_section23_B = new Array([119.957608, 32.321014,
                                   119.97313, 32.315155,
                                   119.983766, 32.303925,
                                   119.99124, 32.288542,
                                   120.005326, 32.266806,
                                   120.01165, 32.25386
                                  ],
                                 []);
var road_section22_B = new Array([120.01165, 32.25386,
                                   120.038383, 32.235781,
                                   120.061092, 32.214766,
                                   120.078627, 32.204745,
                                   120.097312, 32.198146,
                                   120.119734, 32.178344
                                  ],
                                 []);
var road_section21_B = new Array([120.119734, 32.178344,
                                   120.137556, 32.171987,
                                   120.148767, 32.167097,
                                   120.163427, 32.156093,
                                   120.222931, 32.132368
                                  ],
                                 []);
var road_section20_A = new Array([120.223793, 32.136771,
                                      120.225806, 32.132858,
                                      120.229255, 32.127965,
                                      120.23328, 32.112797,
                                      120.237304, 32.097382,
                                      120.238454, 32.080495,
                                      120.242478, 32.066788,
                                      120.245353, 32.054303,
                                      120.246215, 32.041816,
                                      120.248227, 32.031286,
                                      120.255126, 32.011938,
                                      120.256851, 32.00165
                                  ],
                                 []);
var road_section19_A = new Array([120.256851, 32.00165,
                                      120.273524, 31.968573,
                                      120.295658, 31.927394,
                                      120.305431, 31.912928,
                                      120.310893, 31.879819,
                                      120.313768, 31.860684,
                                      120.31693, 31.847679,
                                      120.326128, 31.826819
                                  ],
                                 []);
var road_section20_B = new Array([120.222931, 32.132368,
                                      120.222931, 32.131635,
                                      120.226668, 32.127476,
                                      120.230405, 32.111329,
                                      120.234717, 32.087593,
                                      120.236729, 32.073152,
                                      120.241328, 32.055037,
                                      120.242478, 32.034714,
                                      120.251102, 32.008019,
                                      120.256564, 31.988175
                                  ],
                                 []);
var road_section19_B = new Array([120.256564, 31.988175,
                                      120.289046, 31.932542,
                                      120.294508, 31.922736,
                                      120.301695, 31.911947,
                                      120.305431, 31.901157,
                                      120.307156, 31.876875,
                                      120.311181, 31.854795,
                                      120.317217, 31.8359,
                                      120.321242, 31.82731
                                  ],
                                 []);
var road_section7_A = new Array([118.901775, 32.069113,
                                      118.917873, 32.070092,
                                      118.941444, 32.074498,
                                      118.947768, 32.074254,
                                      118.981114, 32.067889,
                                      118.994624, 32.067155,
                                      119.011872, 32.063238,
                                      119.025095, 32.062259
                                      ],
                                 [118.901775, 32.06893,
                                 118.906015, 32.069603,
                                 118.915286, 32.069909,
                                 118.918017, 32.070398,
                                 118.921179, 32.070521,
                                 118.933036, 32.073091,
                                 118.940223, 32.074192,
                                 118.947337, 32.073948,
                                 118.953733, 32.073213,
                                 118.967387, 32.070154,
                                 118.972921, 32.068746,
                                 118.978814, 32.067522,
                                 118.983701, 32.067033,
                                 118.993115, 32.066971,
                                 118.998289, 32.066115,
                                 119.001954, 32.065074,
                                 119.008063, 32.063116,
                                 119.012662, 32.062137,
                                 119.01719, 32.061769,
                                 119.024448, 32.062075,
                                 119.026963, 32.062137,
                                 119.030413, 32.062687]);

var road_section8_A = new Array([119.025095, 32.062259,
                                      119.051541, 32.069113,
                                      119.063901, 32.070337,
                                      119.084311, 32.067155,
                                      119.102133, 32.058587,
                                      119.129154, 32.055159,
                                      119.139215, 32.05369
                                      ],
                                 [119.030413, 32.062687,
                                 119.039611, 32.065135,
                                 119.044929, 32.066849,
                                 119.04996, 32.068073,
                                 119.055134, 32.06893,
                                 119.060093, 32.069297,
                                 119.06886, 32.06893,
                                 119.074322, 32.068257,
                                 119.080071, 32.067155,
                                 119.08467, 32.065625,
                                 119.088551, 32.064217,
                                 119.095594, 32.060729,
                                 119.10084, 32.058097,
                                 119.108457, 32.055955,
                                 119.114494, 32.054976,
                                 119.12319, 32.054609,
                                 119.128364, 32.054425,
                                 119.138137, 32.05314,
                                 119.14324, 32.052834,
                                 119.155888, 32.053017]);

var road_section9_A = new Array([119.139215, 32.05369,
                                      119.158762, 32.054425,
                                      119.192682, 32.052711,
                                      119.20878, 32.050263,
                                      119.230627, 32.050263,
                                      119.252186, 32.04659,
                                      119.272596, 32.046835],
                                 [119.155888, 32.053017,
                                 119.167027, 32.053262,
                                 119.175291, 32.052466,
                                 119.179891, 32.052099,
                                 119.186143, 32.051977,
                                 119.193545, 32.051854,
                                 119.206121, 32.049896,
                                 119.211295, 32.049528,
                                 119.222506, 32.049406,
                                 119.22883, 32.04959,
                                 119.242053, 32.047386,
                                 119.249384, 32.046223,
                                 119.256498, 32.045856,
                                 119.264834, 32.046162,
                                 119.271877, 32.045794,
                                 119.284741, 32.044509,
                                 119.297533, 32.044325,
                                 119.300695, 32.044142,
                                 119.310971, 32.042795,
                                 119.318661, 32.042673]);

var road_section10_A = new Array([
                                      119.272596, 32.046835,
                                      119.297892, 32.045121,
                                      119.314852, 32.042917,
                                      119.353084, 32.043162,
                                      119.379243, 32.047814,
                                      119.409713, 32.053201],
                                 [119.318661, 32.042673,
                                 119.326925, 32.043101,
                                 119.33598, 32.043223,
                                 119.345754, 32.042611,
                                 119.355312, 32.04304,
                                 119.360702, 32.043407,
                                 119.364654, 32.044203,
                                 119.368822, 32.045366,
                                 119.373637, 32.046039,
                                 119.380321, 32.046896,
                                 119.387363, 32.047631,
                                 119.394478, 32.048794,
                                 119.399724, 32.050079,
                                 119.404826, 32.051426,
                                 119.409929, 32.053384]);
var road_section7_B = new Array([118.9035, 32.067277,
                                       118.917298, 32.068012,
                                       118.943169, 32.071928,
                                       118.979964, 32.065074,
                                       118.998361, 32.06385,
                                       119.013309, 32.059444,
                                       119.022507, 32.059199

                                       ],
                                 [118.90235, 32.067951,
                                 118.906949, 32.068563,
                                 118.916939, 32.068807,
                                 118.925131, 32.070154,
                                 118.935695, 32.072418,
                                 118.943744, 32.073152,
                                 118.953518, 32.071989,
                                 118.960345, 32.070704,
                                 118.966813, 32.06893,
                                 118.973065, 32.067583,
                                 118.979748, 32.066298,
                                 118.984276, 32.065992,
                                 118.993259, 32.065931,
                                 118.998577, 32.064952,
                                 119.007128, 32.062259,
                                 119.011368, 32.061341,
                                 119.016112, 32.060851]);

var road_section8_B = new Array([119.022507, 32.059199,
                                       119.036018, 32.061157,
                                       119.056427, 32.066298,
                                       119.066776, 32.066543,
                                       119.076837, 32.065809,
                                       119.097534, 32.05724,
                                       119.104433, 32.054058,
                                       119.134041, 32.05112],
                                 [119.016112, 32.060851,
                                 119.02143, 32.060545,
                                 119.026388, 32.060974,
                                 119.035156, 32.062565,
                                 119.045432, 32.065747,
                                 119.052691, 32.067461,
                                 119.058727, 32.068134,
                                 119.065698, 32.068195,
                                 119.073531, 32.067461,
                                 119.080286, 32.06587,
                                 119.088192, 32.063177,
                                 119.099834, 32.057546,
                                 119.104505, 32.055833,
                                 119.109823, 32.054547,
                                 119.115788, 32.053874]);
var road_section9_B = new Array([
                                       119.134041, 32.05112,
                                       119.160775, 32.051365,
                                       119.193545, 32.049161,
                                       119.236376, 32.045488,
                                       119.282657, 32.04206],
                                 [119.115788, 32.053874,
                                 119.122543, 32.053629,
                                 119.128508, 32.053323,
                                 119.141443, 32.051671,
                                 119.15711, 32.052099,
                                 119.168967, 32.052038,
                                 119.179316, 32.050936,
                                 119.192179, 32.050752,
                                 119.206049, 32.048916,
                                 119.210792, 32.048488,
                                 119.224375, 32.048488,
                                 119.229405, 32.048243,
                                 119.241981, 32.046284,
                                 119.251108, 32.045121,
                                 119.25657, 32.044693,
                                 119.263756, 32.044999]);
var road_section10_B = new Array([
                                       119.282657, 32.04206,
                                       119.297605, 32.04206,
                                       119.317439, 32.039612,
                                       119.335836, 32.041081,
                                       119.353371, 32.039857,
                                       119.379817, 32.044264,
                                       119.41115, 32.05014],
                                 [119.263756, 32.044999,
                                 119.271518, 32.044876,
                                 119.283591, 32.043591,
                                 119.298395, 32.04307,
                                 119.312624, 32.041601,
                                 119.327716, 32.041969,
                                 119.338783, 32.04203,
                                 119.3487, 32.041479,
                                 119.35603, 32.041662,
                                 119.36451, 32.04307,
                                 119.370188, 32.044295,
                                 119.376799, 32.045335,
                                 119.383554, 32.04607,
                                 119.391891, 32.046866,
                                 119.397784, 32.048457,
                                 119.410144, 32.052191]);
var road_section11_A = new Array([119.409713, 32.054058,
                                      119.425811, 32.058464,
                                      119.437884, 32.059689,
                                      119.453407, 32.059199,
                                      119.468929, 32.061647,
                                      119.486752, 32.061402,
                                      119.503424, 32.05724,
                                      119.51636, 32.053568,
                                      119.544818, 32.052099,
                                      119.56609, 32.047447
                                       ],
                                 []);
var road_section12_A = new Array([
                                      119.56609, 32.047447,
                                      119.58305, 32.047202,
                                      119.600298, 32.045488,
                                      119.619845, 32.040346,
                                      119.635942, 32.033,
                                      119.648303, 32.025408,
                                      119.658651, 32.018306,
                                      119.669575, 32.009488,
                                      119.679348, 31.998955,
                                      119.685385, 31.99087
                                       ],
                                 []);
var road_section13_A = new Array([119.685385, 31.99087,
                                      119.695446, 31.981315,
                                      119.705507, 31.974209,
                                      119.715856, 31.967593,
                                      119.728504, 31.959995,
                                      119.74532, 31.952765,
                                      119.786714, 31.937568
                                       ],
                                 []);

var road_section14_A = new Array([119.786714, 31.937568,
                                      119.805686, 31.927762,
                                      119.821496, 31.919916,
                                      119.845643, 31.911824,
                                      119.859441, 31.905203,
                                      119.866627, 31.899318,
                                      119.8787, 31.894903,
                                      119.886462, 31.89196
                                       ],
                                 []);

var road_section15_A = new Array([119.886462, 31.89196,
                                      119.905434, 31.88313,
                                      119.914058, 31.878224,
                                      119.937342, 31.868902,
                                      119.945966, 31.864486,
                                      119.955739, 31.859089,
                                      119.965225, 31.855899,
                                      119.985922, 31.851973,
                                      120.00317, 31.846084,
                                      120.01553, 31.838722,
                                      120.047151, 31.818106
                                       ],
                                 []);
var road_section16_A = new Array([
                                      120.047151, 31.818106,
                                      120.064111, 31.810742,
                                      120.091707, 31.790364,
                                      120.110679, 31.766544,
                                      120.134825, 31.746403],
                                 []);
var road_section11_B = new Array([119.410863, 32.051609,
                                      119.425523, 32.055527,
                                      119.438171, 32.056996,
                                      119.456281, 32.056751,
                                      119.478415, 32.058709,
                                      119.488764, 32.057485,
                                      119.49825, 32.055527,
                                      119.516935, 32.050875,
                                      119.541081, 32.049161,
                                      119.569252, 32.043774
                                      ],
                                 []);
var road_section12_B = new Array([119.569252, 32.043774,
                                       119.587937, 32.04353,
                                      119.60346, 32.04206,
                                      119.615245, 32.038877,
                                      119.641691, 32.025653,
                                      119.660664, 32.012673,
                                      119.674749, 31.99871,
                                      119.68481, 31.98597],
                                 []);
var road_section13_B = new Array([119.68481, 31.98597,
                                      119.714131, 31.964652,
                                      119.726492, 31.957545,
                                      119.744314, 31.949947,
                                      119.785133, 31.934994
                                       ],
                                 []);

var road_section14_B = new Array([119.785133, 31.934994,
                                      119.796919, 31.9296,
                                      119.817616, 31.917832,
                                      119.843199, 31.909004,
                                      119.859872, 31.901157,
                                      119.87022, 31.89429,
                                      119.884306, 31.889875
                                       ],
                                 []);

var road_section15_B = new Array([119.884306, 31.889875,
                                      119.901841, 31.8808,
                                      119.915064, 31.873686,
                                      119.9257, 31.870252,
                                      119.94036, 31.863873,
                                      119.952721, 31.857249,
                                      119.964794, 31.852832,
                                      119.980029, 31.850378,
                                      119.995552, 31.845716,
                                      120.005613, 31.841054,
                                      120.044132, 31.816756
                                       ],
                                 []);
var road_section16_B = new Array([120.044132, 31.816756,
                                      120.055056, 31.811846,
                                      120.076328, 31.798099,
                                      120.094437, 31.781893,
                                      120.104498, 31.768632,
                                      120.117147, 31.754141,
                                      120.132094, 31.744806
                                       ],
                                 []);
var road_section17_A = new Array([120.134107, 31.748245,
                                      120.149054, 31.758071,
                                      120.167739, 31.766421,
                                      120.188149, 31.772807,
                                      120.207408, 31.782139,
                                      120.219194, 31.786313,
                                      120.22983, 31.79196],
                                 []);
var road_section18_A = new Array([120.22983, 31.79196,
                                     120.245928, 31.796871,
                                      120.260301, 31.800308,
                                      120.273236, 31.80841,
                                      120.287609, 31.818965,
                                      120.299395, 31.824119,
                                      120.323829, 31.82731],
                                 []);
var road_section17_B = new Array([120.135544, 31.745052,
                                      120.14503, 31.749965,
                                      120.153079, 31.75586,
                                      120.163427, 31.760772,
                                      120.168314, 31.76372,
                                      120.174063, 31.76593,
                                      120.191023, 31.771333,
                                      120.209421, 31.779437,
                                      120.226668, 31.786804
                                       ],
                                 []);
var road_section18_B = new Array([120.226668, 31.786804,
                                       120.236154, 31.790733,
                                      120.2626, 31.79859,
                                      120.274961, 31.804973,
                                      120.284735, 31.814056,
                                      120.295658, 31.818474,
                                      120.308019, 31.822892,
                                      120.324691, 31.824119],
                                 []);
var road_section29_A = new Array([119.372631, 32.345421,
                                      119.373206, 32.337855,
                                      119.372056, 32.324431,
                                      119.372344, 32.314911,
                                      119.375506, 32.301483,
                                      119.376655, 32.27853,
                                      119.379243, 32.264852,
                                      119.37838, 32.253616,
                                      119.373781, 32.240424,
                                     119.372631, 32.235293],
                                 [119.371409, 32.345604,
                                 119.371912, 32.340967,
                                 119.371841, 32.33572,
                                 119.371122, 32.328397,
                                 119.370763, 32.323577,
                                 119.370763, 32.319427,
                                 119.371409, 32.31369,
                                 119.372487, 32.308258,
                                 119.37414, 32.300995,
                                 119.375074, 32.296112,
                                 119.375362, 32.290007,
                                 119.37529, 32.285001,
                                 119.375506, 32.280178,
                                 119.376009, 32.275172,
                                 119.37723, 32.269615,
                                 119.377733, 32.261372,
                                 119.376871, 32.255387,
                                 119.374715, 32.247203,
                                 119.372272, 32.239874]);
var road_section30_A = new Array([119.372631, 32.235293,
                                      119.371769, 32.223564,
                                      119.387579, 32.191301,
                                      119.403102, 32.171743,
                                      119.410575, 32.159028,
                                      119.418624, 32.148756
                                      ],
                                 [119.372272, 32.239874,
                                 119.371409, 32.234804,
                                 119.370259, 32.228817,
                                 119.370547, 32.224419,
                                 119.370834, 32.222403,
                                 119.374715, 32.215194,
                                 119.377374, 32.208351,
                                 119.379961, 32.203707,
                                 119.384057, 32.195213,
                                 119.387579, 32.189407,
                                 119.393184, 32.182623,
                                 119.398718, 32.175961,
                                 119.401664, 32.171498,
                                 119.404611, 32.165813,
                                 119.408635, 32.160189,
                                 119.411869, 32.156093,
                                 119.415678, 32.151813]);
var road_section31_A = new Array([119.418624, 32.148756,
                                     119.420924, 32.141663,
                                     119.420062, 32.130656,
                                       119.419487, 32.121849,
                                      119.420062, 32.111084,
                                      119.41575, 32.09469,
                                      119.414312, 32.084901,
                                      119.412013, 32.066788,
                                      119.411438, 32.060423,
                                      119.41115, 32.051854],
                                 [119.415678, 32.151813,
                                 119.417977, 32.146677,
                                 119.418552, 32.142214,
                                 119.418265, 32.136038,
                                 119.417977, 32.132552,
                                 119.417834, 32.127293,
                                 119.418768, 32.120504,
                                 119.418768, 32.114265,
                                 119.418193, 32.10876,
                                 119.416468, 32.101786,
                                 119.414672, 32.096709,
                                 119.413019, 32.089612,
                                 119.41151, 32.077497,
                                 119.410001, 32.066849,
                                 119.409641, 32.059627,
                                 119.41036, 32.053813,
                                 119.410575, 32.05265]);
var road_section29_B = new Array([119.369469, 32.3442,
                                      119.370044, 32.335171,
                                      119.368607, 32.320281,
                                      119.370044, 32.307343,
                                      119.373493, 32.295379,
                                      119.373781, 32.278285,
                                      119.375506, 32.259723,
                                      119.374068, 32.249707,
                                      119.369469, 32.23627],
                                 [119.370116, 32.34536,
                                 119.370547, 32.341089,
                                 119.370619, 32.33755,
                                 119.370475, 32.333523,
                                 119.369828, 32.329313,
                                 119.369613, 32.326079,
                                 119.369469, 32.320342,
                                 119.3699, 32.315155,
                                 119.37105, 32.308441,
                                 119.372775, 32.301972,
                                 119.373781, 32.295074,
                                 119.374068, 32.289397,
                                 119.374068, 32.283048,
                                 119.374356, 32.277919,
                                 119.375721, 32.270104,
                                 119.376512, 32.263387,
                                 119.376009, 32.256364,
                                 119.3745, 32.250929,
                                 119.372631, 32.245188]);
var road_section30_B = new Array([119.369469, 32.23627,
                                      119.368607, 32.225519,
                                      119.370619, 32.216477,
                                      119.376655, 32.204501,
                                      119.387004, 32.185923,
                                      119.39994, 32.169298,
                                      119.408563, 32.156582,
                                      119.41575, 32.147533],
                                 [119.372631, 32.245188,
                                 119.370906, 32.240118,
                                 119.369541, 32.231994,
                                 119.368966, 32.227657,
                                 119.369253, 32.223808,
                                 119.371409, 32.218065,
                                 119.378452, 32.203523,
                                 119.383123, 32.194051,
                                 119.385782, 32.18959,
                                 119.3911, 32.183112,
                                 119.39534, 32.178161,
                                 119.399365, 32.173027,
                                 119.40188, 32.167586,
                                 119.404108, 32.164224,
                                 119.406767, 32.160189,
                                 119.410144, 32.156215,
                                 119.414744, 32.150774,
                                 119.416612, 32.146372]);
var road_section31_B = new Array([119.41575, 32.147533,
                                      119.41575, 32.135304,
                                      119.416037, 32.12503,
                                      119.417187, 32.113042,
                                      119.414887, 32.102765,
                                      119.411438, 32.092977,
                                      119.408851, 32.073887,
                                      119.407701, 32.064095,
                                      119.407701, 32.056996,
                                      119.408851, 32.051365],
                                 [119.416612, 32.146372,
                                 119.417474, 32.142397,
                                 119.416971, 32.136527,
                                 119.416612, 32.130778,
                                 119.416828, 32.125274,
                                 119.417403, 32.12081,
                                 119.417546, 32.116039,
                                 119.416828, 32.109066,
                                 119.41539, 32.102704,
                                 119.41345, 32.097321,
                                 119.412372, 32.093038,
                                 119.41151, 32.089061,
                                 119.410504, 32.08074,
                                 119.409354, 32.072295,
                                 119.408707, 32.065931,
                                 119.408348, 32.058893,
                                 119.409426, 32.052405]);