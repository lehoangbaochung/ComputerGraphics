namespace ComputerGraphics.Interfaces
{
    public interface IOpenGLMaterial
    {
        /// <summary>
        /// Chiếu sáng toàn phần cho đối tượng của vật
        /// </summary>
        float[] Ambient { get; set; }

        /// <summary>
        /// Tạo ánh sáng phản xạ trong đối tượng
        /// </summary>
        float[] Specular { get; set; }

        /// <summary>
        /// Tạo ánh sáng khuếch tán cho đối tượng
        /// </summary>
        float[] Diffuse { get; set; }

        /// <summary>
        /// Điều chỉnh cường độ điểm chiếu sáng phản xạ
        /// </summary>
        float Shininess { get; set; }
    }
}
