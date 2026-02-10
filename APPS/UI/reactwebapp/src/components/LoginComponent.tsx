import { useState } from "react";
import { useNavigate  } from "react-router";


function LoginComponent()
{
    // 
    const [username,setusername] = useState(''); //hook
    const [password,setpassword] = useState(''); //hook
    const [status,setstatus] = useState('');

    const navigate = useNavigate();


    const submitForm = () =>
        {
            if(username === "admin" && password === "password")
            {
                localStorage.setItem("username",username);
                navigate("/home");

            }
            else
            {
                setstatus("Invalid Login");
            }
        }

    /// JSX (not html)
    return(
        <div>
            <form method="post" action={submitForm}>
            Username : <input type="text" name="t1"  value={username}  onChange={(event) => setusername(event.target.value)}></input><br/>
            Password  : <input type="password" name="t1" value={password}  onChange={(event) => setpassword(event.target.value)}></input><br/>
            <input type="submit" name="s1"></input>
            <br/>
            <br />
            <label>{status}</label>
            </form>
        </div>
    )

}

export default LoginComponent;