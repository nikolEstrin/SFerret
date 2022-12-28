import Nav from 'react-bootstrap/Nav';

function OptionsList() {


    return(
        <Nav fill variant="tabs" defaultActiveKey="/">
        <Nav.Item>
          <Nav.Link eventKey="disabled" disabled>Hello UserFullName</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/WatchList">WatchList</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/Feed">Feed</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link href="/Search">Search</Nav.Link>
        </Nav.Item>
        <Nav.Item>
          <Nav.Link eventKey="disabled" disabled>Disabled</Nav.Link>
        </Nav.Item>
        </Nav>
    );
}

export default OptionsList;
