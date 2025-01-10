const baseUrl = 'http://localhost:5006';

export const createPost = async (content) => {
    const response = await fetch(`${baseUrl}/api/posts`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(content),
    });
    const data = await response.json();
    return data;
};

export const getPosts = async (keyword, sort) => {
    let url = `${baseUrl}/api/posts?`;
    if(keyword)
        url += `keyword=${keyword}&`;
    if(sort)
        url += `sort=${sort}&`;

    const response = await fetch(url);
    const data = await response.json();
    return data;
};


export const searchPost = async (keyword) => {
    const response = await fetch(`${baseUrl}/api/posts`,{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(keyword),
    });
    const data = await response.json();
    return data;
};
