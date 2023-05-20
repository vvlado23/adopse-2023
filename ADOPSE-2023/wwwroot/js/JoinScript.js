//apothikeuei tin metavliti ston xoro localStorage
function getTeacher(teacher, depart, desc, email, pSite) {


    localStorage.clear();
    localStorage.setItem('teacher-name', teacher);
    localStorage.setItem('teacher-depart', depart);   
    localStorage.setItem('teacher-desc', desc);
    localStorage.setItem('teacher-email', email);
    localStorage.setItem('teacher-pSite', pSite);
}
