import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import Navbar from '../../Components/Navbar/navbarComponent';
import { Button, Col, Container, Form, Row, Card } from 'react-bootstrap';
import Axios from 'axios';
import Cookies from 'js-cookie';
import { iMovie } from '../../Interfaces/iMovie';
import GroupCard from '../../Components/GroupCard/groupCard';
import './groupPageStyle.css';
import { iGroup } from '../../Interfaces/iGroup';




class groupPage extends Component {
    state = {
        movies: Array<iMovie>(),
        userGroups: Array<iGroup>(),
        groupID: 0,
        joinGroupID: 0,
        message1: "",
        message2: "",
        groupName: ""
    }

    componentDidMount() {
        this.GetUserGroups();
        document.title = "MovieMates | Group";
    }

    GetUserGroups(){
        Axios.get(`api/user/${Cookies.get("UserID")}/groups`).then(response => {
            this.setState({ userGroups: response.data });
        })
    }

    returnCard(mymovies: Array<iMovie>) {
        if (mymovies.length !== 0) {
            return (<GroupCard movies={this.state.movies} />);
        }
        else {
            return (<Card className="groupCard"> </Card>)
        }


    }

    SetGroup(value: string) {
        this.setState({ groupID: value }, () => {

            if (this.state.groupID !== 0) {
                Axios.get(`api/group/${this.state.groupID}/movies`).then(response => {
                    this.setState({ movies: response.data });
                });
            };
        });
    }

    SetJoinID(value: string) {
        if (value.length <= 6) {
            this.setState({ joinGroupID: value })
        }
    }

    CheckLength(value : string){
        if (value.length <= 5){
            return true;
        }
        return false;
    }

    CreateGroup(e: any){
        e.preventDefault();

        Axios.post(`api/group/create/${this.state.groupName}`).then(response =>{
            var myMessage = "The group " + response.data.name + " has been created! (" +response.data.joinID+")";
            this.setState({ message1: myMessage})

            Axios.patch(`api/group/${response.data.joinID}/add/${Cookies.get("UserID")}`).then(response => {
            this.GetUserGroups(); 
            }).catch(error => {
                this.setState({ message1: error.response.data });
            });
        });

    }

    JoinGroup(e: any) {
        e.preventDefault();

        Axios.patch(`api/group/${this.state.joinGroupID}/add/${Cookies.get("UserID")}`).then(response => {
            this.setState({ message2: response.data }, () => this.GetUserGroups()   );

        }).catch(error => {
            this.setState({ message2: error.response.data });
        })
    }


    render() {
        let groups;
        groups = this.state.userGroups.map(g => {
            return (
                <option value={g.id}>{g.name} ({g.joinID})</option>
            )
        });


        return (
            <>
                <Navbar />
                <Container className="container">
                    <Row>
                        <Col>
                        <Form onSubmit={(e) => this.CreateGroup(e)}>
                                <Form.Group>
                                    <Form.Label className="grouptitle">Create Group</Form.Label>
                                    <Form.Label className="message"> {this.state.message1} </Form.Label>
                                    <Form.Control type="text" value={this.state.groupName} onChange={(e) => this.setState({groupName: e.target.value})} />
                                </Form.Group>
                                <Button type="submit" disabled={this.CheckLength(this.state.groupName)}>Create</Button>
                            </Form>
                            <hr />
                            <Form onSubmit={(e) => this.JoinGroup(e)}>
                                <Form.Group>
                                    <Form.Label className="grouptitle">Join Group:</Form.Label>
                                    <Form.Label className="message"> {this.state.message2} </Form.Label>
                                    <Form.Control type="number" value={this.state.joinGroupID} onChange={(e) => this.SetJoinID(e.target.value)} />
                                </Form.Group>
                                <Button type="submit" disabled={this.CheckLength(this.state.joinGroupID.toString())} >Join</Button>
                            </Form>
                            <hr />
                            <Form>
                                <Form.Group>
                                    <Form.Label className="grouptitle">Choose group</Form.Label>
                                    <Form.Control as="select" onChange={(e) => this.SetGroup(e.target.value)} >
                                        <option> Choose a group... </option>
                                        {groups}
                                    </Form.Control>
                                </Form.Group>
                            </Form>
                        </Col>
                        <Col>
                            {this.returnCard(this.state.movies)}
                        </Col>
                    </Row>
                </Container>
            </>
        );
    }

}

export default groupPage;