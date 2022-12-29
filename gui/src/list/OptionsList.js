import Nav from 'react-bootstrap/Nav';

function OptionsList() {


    return(
        <Nav id='upper_tub' fill variant="tabs" defaultActiveKey="/" className='fixed-top bg-dark navbar-dark'>
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
