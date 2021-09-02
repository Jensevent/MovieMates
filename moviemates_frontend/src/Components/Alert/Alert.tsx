import React, { Component } from 'react';
import "./AlertStyle.css";

interface props{
    title: "",
    context:""
}


class Alert extends Component<props> {
    render() {
        return (
            <div className="movie-alert">
                <div className="header">
                    {this.props.title}
                </div>
                <div className="context">
                    {this.props.context}
                </div>
            </div>
        );
    }
}

export default Alert;