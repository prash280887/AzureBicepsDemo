import { Link , useNavigate } from "react-router";

function HomeComponent()
{
    

    const username =  localStorage.getItem("username");
    
    const navigate = useNavigate();
const logout = () =>
{
   localStorage.clear();

   navigate("/login");
}


return(
<div>
    <nav className="nav"> 
       <span style={{color : "blue"}}>Welcome {username}  </span>      
        <Link to="/home">Home</Link>
       <a href="" onClick={logout}>Logout</a>
    </nav>

Welcome {username} ,This is my Home page
</div>

)

}

export default HomeComponent;