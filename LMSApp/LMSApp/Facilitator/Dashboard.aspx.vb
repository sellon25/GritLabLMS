Public Class Dashboard
    Inherits System.Web.UI.Page

    Dim numCourses As Integer
    Dim numProjects As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim facilitatorId As String = Session("ID").ToString()

        numCourses = 0
        numProjects = 0

        ' Fetch courses and projects
        Dim courses As List(Of Course) = GetCoursesByFacilitator(facilitatorId)
        Dim projects As List(Of Project) = GetProjectsByFacilitator(facilitatorId)

        'display correct values
        projectsAssigned.Text = numProjects.ToString()
        coursesAssigned.Text = numCourses.ToString()

    End Sub

    Private Function GetCoursesByFacilitator(facilitatorId As String) As List(Of Course)
        Dim filter As String = "WHERE userId = '" & facilitatorId & "'"
        Dim courseEnrollments As List(Of Course_Enrollment) = New Course_Enrollment().listall(filter)
        Dim facilitatorCourses As New List(Of Course)

        For Each enrollment As Course_Enrollment In courseEnrollments
            Dim course As Course = Course.load(enrollment.course_id)
            If course IsNot Nothing Then
                course.name = Trim(course.name)
                facilitatorCourses.Add(course)
                numCourses += 1

            End If
        Next

        Return facilitatorCourses
    End Function

    Private Function GetProjectsByFacilitator(facilitatorId As String) As List(Of Project)
        Dim filter As String = "WHERE userId = '" & facilitatorId & "'"
        Dim projectEnrollments As List(Of Project_Enrollment) = New Project_Enrollment().listall(filter)
        Dim facilitatorProjects As New List(Of Project)

        For Each enrollment As Project_Enrollment In projectEnrollments
            Dim project As Project = Project.load(enrollment.project_id)
            If project IsNot Nothing Then
                project.name = Trim(project.name)
                facilitatorProjects.Add(project)
            End If
        Next

        Return facilitatorProjects
    End Function

End Class