//apothikeuei tin metavliti ston xoro localStorage
function getTeacher(teacherName) {
    var teacher = teacherName.innerHTML;
    localStorage.setItem('teacher-name', teacher);
    //console.log(teacher);
}

//den leitrougei me call function alla me ensomatomeno js
function SetTeacher() {
    var teacherName = localStorage.getItem('teacher-name')
    document.getElementById("PlaceholderKathig").innerHTML = teacherName;
}