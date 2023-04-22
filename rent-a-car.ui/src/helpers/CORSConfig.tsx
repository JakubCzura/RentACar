const corsConfig = () => {
    return {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Headers': 'Origin, Methods, Content-Type, X-Auth-Token',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': ' GET, POST, PATCH, PUT, DELETE, OPTIONS',
        'Access-Control-Allow-Credentials': 'false',
        'Accept': 'application/json, text/plain, */*'
      }
    };
}

export default corsConfig;