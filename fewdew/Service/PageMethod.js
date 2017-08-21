    function PostComment(postButton)
    {
        var TopParentsChilds= postButton.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.childNodes;
        var postButtonParentChilds= postButton.parentNode.childNodes;
        alert(TopParentsChilds.length);
        return;
        
        if(is_ie6())
        {
            if(postButtonParentChilds[0].value!="")
            {
            PageMethods.PostCommentAndReturnCommentHtml(postButtonParentChilds[0].value,TopParentsChilds[1].getAttribute('name'),OnCommentPostSucceeded,OnFailed,postButton);
            }
        }
        else
        {
            if(postButtonParentChilds[1].value!="")
            {
            PageMethods.PostCommentAndReturnCommentHtml(postButtonParentChilds[1].value,TopParentsChilds[1].getAttribute('name'),OnCommentPostSucceeded,OnFailed,postButton);
            }
        }        
        

    }
    function OnCommentPostSucceeded(result, userContext, methodName) 
    {
    userContext.parentNode.parentNode.parentNode.parentNode.parentNode.parentNode.innerHTML=result;
    }

function ShowAllComment(seeAllButton)
{
    var seeAllsParentChilds= seeAllButton.parentNode.childNodes;
    PageMethods.ShowAllComment(seeAllButton.getAttribute('name'),OnShowAllSucceed,OnFailed,seeAllButton);
}
function OnShowAllSucceed(result, userContext, methodName) 
{
    userContext.parentNode.innerHTML=result;
}

function GetMyName(key) 
{
    PageMethods.GetMyName(key, 
        OnSucceeded, OnFailed,"MyContext");
}

function is_ie6(){
    var IE6=(navigator.userAgent.toLowerCase().indexOf('msie 6') != -1) && (navigator.userAgent.toLowerCase().indexOf('msie 7') == -1)
return IE6;
}


function OnSucceeded(result, userContext, methodName) 
{
 //alert(result);
 var spn=document.getElementById("ResultId");
 spn.innerHTML=spn.innerHTML+result;
    if (methodName == "GetSessionValue")
    {
        
//        alert(result);
    }
}

// Callback function invoked on failure 
// of the page method.
function OnFailed(error, userContext, methodName) 
{
    if(error !== null) 
    {
        alert(error.get_message());
    }
}