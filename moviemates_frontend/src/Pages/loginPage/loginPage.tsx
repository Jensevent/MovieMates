import React, { Component } from 'react';
import LoginCard from '../../Components/Login/loginCard';
import 'bootstrap/dist/css/bootstrap.css';
import './loginStyle.css';


class loginPage extends Component {
    componentDidMount(){
        document.title = "MovieMates | Login";
    }
    
    render() {
        return (
            <div className="page">
                <LoginCard />
            </div>      
        );
    }

}

export default loginPage;