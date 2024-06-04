function toggleSidebar() {
    const sidebar = document.getElementById("NavSideBar");
    if (sidebar.classList.contains("hide")) {
        sidebar.classList.remove("hide");
        sidebar.classList.add("show");
    }
    else if (sidebar.classList.contains("show")) {
        sidebar.classList.remove("show");
        sidebar.classList.add("hide");
    }

}

