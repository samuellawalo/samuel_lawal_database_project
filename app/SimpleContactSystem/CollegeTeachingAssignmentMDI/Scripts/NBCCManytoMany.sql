use NBCCCollege


select q.NextCourseId,
q.NextInstructorId,
q.NextTerm,
q.PreviousCourseId,
q.PreviousInstructorId,
q.PreviousTerm,
q.RowNumber,
(Select Top(1) CourseId from Assignments order by CourseId) as FirstCourseId,
(Select Top(1) InstructorId from Assignments order by CourseId) as FirstInstructorId,
(Select Top(1) Term from Assignments order by CourseId) as FirstTerm,
(Select Top(1) CourseId from Assignments order by CourseId desc) as LastCourseId,
(Select Top(1) InstructorId from Assignments order by CourseId desc) as LastInstructorId,
(Select Top(1) Term from Assignments order by CourseId desc) as LastTrerm
from(
select courseid, instructorid, term,
Lead(CourseId) Over(order by CourseId) as NextCourseId,
Lead(InstructorId) Over(Order by CourseId) as NextInstructorId,
Lead(term) Over(order by courseId) as NextTerm,
Lag(CourseId) Over(order by CourseId) as PreviousCourseId,
Lag(InstructorId) Over(order by CourseId) as PreviousInstructorId,
Lag(Term) Over(order by CourseId) as PreviousTerm,
ROW_NUMBER() Over(Order by CourseId) as RowNumber
from Assignments) as q
where q.CourseId= 4 and q.InstructorId = 1 and q.Term = 4