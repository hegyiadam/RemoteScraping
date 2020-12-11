import logo from "./logo.svg";
import "./App.css";
import GetGetSessionData from "./DAL/GetGetSessionData";
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";
import Container from "@material-ui/core/Container";
import Grid from "@material-ui/core/Grid";
import { JsonToTable } from "react-json-to-table";

import React, { Component } from "react";
import { useParams } from "react-router-dom";
import { withRouter } from "react-router";

class Session extends React.Component {
    constructor(props) {
        super(props);
        const sessionid = this.props.match.params.sessionid;
        this.state = {
            sessionid: sessionid,
            sessionData: [],
        };
    }
    componentWillMount() {
        GetGetSessionData(
            "http://localhost:3333/api/method/GetResult",
            "http://localhost:3333/api/method/GetFutureResult",
            this.state.sessionid,
            this.updateSessionData,
            this
        );
    }
    updateSessionData(component, data) {
        component.setState({ sessionData: data });
    }
    render() {
        return (
            <Container maxWidth="sm">
                <h1>Session results</h1>
                <h2>Session id: {this.state.sessionid}</h2>
                <JsonToTable json={this.state.sessionData} />
            </Container>
        );
    }
}
export default Session;
