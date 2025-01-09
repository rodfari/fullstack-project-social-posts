
const Posts = ({ data }) => {
console.log(data);
  return (
    <>
      {data.map((post) => (
        <div className="post-box" key={post.id}>
          <div className="post">
            <div className="post__user">
              <div className="post__user-avatar">R</div>
              <div className="post__user-name">User name</div>
            </div>
            <div className="post__content">
              <p>
                {post.content}
              </p>
            </div>
            <div className="post__date">
              <p>{post.createdAt}</p>
            </div>
          </div>
        </div>
      ))}
    </>
  );

};

export default Posts;