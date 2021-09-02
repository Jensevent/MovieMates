import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import RegisterComponent from '../../Components/Register/registerCard';


class registerPage extends Component {
    componentDidMount(){
        document.title = "MovieMates | Register";
    }
    
    render() {
        return (
            <>
            <div className="page">
                <RegisterComponent />
            </div>  
            </>          
            
        );
    }

}

export default registerPage;