SELECT 
    (SELECT COUNT(1) FROM Contacts) as contactCount,
    ContactId,
    (
        SELECT TOP(1) ContactId as FirstContactId FROM Contacts ORDER BY ContactName
    ) as FirstContactId,
    q.PreviousContactId,
    q.NextContactId,
    (
        SELECT TOP(1) ContactId as LastContactId FROM Contacts ORDER BY ContactName DESC
    ) as LastContactId,
    q.RowNumber
FROM
(
    SELECT ContactId, ContactName,
    LEAD(ContactId) OVER(ORDER BY ContactName) AS NextContactId,
    LAG(ContactId) OVER(ORDER BY ContactName) AS PreviousContactId,
    ROW_NUMBER() OVER(ORDER BY ContactName) AS 'RowNumber'
    FROM Contacts
) AS q
--WHERE q.ContactId = {id}
ORDER BY q.ContactName;
